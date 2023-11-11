using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Repositories;
using API.Models.Dtos;
using API.Models.Entities;

namespace API.Controllers
{
    public class AnimalsController : BaseApiController
    {
        private readonly IAnimalsRepository _animalRepo;
        private readonly ICagesRepository _cageRepo;
        private readonly IMapper _mapper;

        public AnimalsController(IAnimalsRepository animalRepo, ICagesRepository cageRepo, IMapper mapper)
        {
            _animalRepo = animalRepo;
            _cageRepo = cageRepo;
            _mapper = mapper;
        }

        // GET: api/Animals
        [HttpGet("animals", Name = "GetAnimals")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
        {
            var animals = await _animalRepo.GetAnimals();
            if (!ModelState.IsValid)
                return BadRequest();
            var animaslDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
            return Ok(animaslDto);
        }

        // GET: api/Animals/5
        [HttpGet("animal")]
        public async Task<ActionResult<AnimalDto>> GetAnimal(string id)
        {
            var animal = await _animalRepo.GetAnimalById(id);

            if (animal == null)
            {
                return NotFound();
            }
            var animalDto = _mapper.Map<AnimalDto>(animal);
            return animalDto;
        }

        [HttpGet("cages-by-cageId")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetCagesByCageId([FromQuery] string cageId)
        {
            var cages = await _animalRepo.GetAnimalByCageId(cageId);
            if (!ModelState.IsValid)
                return BadRequest();
            var cagesDto = _mapper.Map<IEnumerable<AnimalDto>>(cages);
            return Ok(cagesDto);
        }

        [HttpGet("cages-by-speciesId")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetCagesBySpeciesId([FromQuery] int speciesId)
        {
            var species = await _animalRepo.GetAnimalBySpeciesId(speciesId);
            if (!ModelState.IsValid)
                return BadRequest();
            var speciesDto = _mapper.Map<IEnumerable<AnimalDto>>(species);
            return Ok(speciesDto);
        }

        [HttpGet("search-animals")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> SearchAnimalsByName([FromQuery] string animalName)
        {
            if (animalName.Trim().Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else
            {
                var animals = await _animalRepo.SearchAnimalsByName(animalName.Trim());
                if (!animals.Any())
                {
                    return NotFound();
                }
                else
                {
                    var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
                    return Ok(animalsDto);
                }
            }
        }

        [HttpDelete("delete-animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AnimalDto>> DeleteAnimal([FromQuery] string animalId)
        {
            var currAnimal = await _animalRepo.GetAnimalById(animalId);
            if (currAnimal != null)
            {
                await _animalRepo.DeleteAnimal(animalId);
                var animals = await _animalRepo.GetAnimals();
                var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
                if (!ModelState.IsValid)
                    BadRequest(ModelState);
                return CreatedAtRoute("GetAnimals", animalsDto);
            }
            return NotFound();
        }

        [HttpPost("create-animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AnimalDto>> CreateNewAnimals([FromBody] AnimalDto animalDto)
        {
            var animals = await _animalRepo.GetAnimals();
            if (animals.SingleOrDefault(animal => animal.AnimalId.Equals(animalDto.AnimalId)) != null)
            {
                return BadRequest(new ProblemDetails { Title = "AnimalId is exist" });
            }
            else
            {
                var animal = _mapper.Map<Animal>(animalDto);
                await _animalRepo.CreateNewAnimal(animal);
                var currCage = _cageRepo.GetCageById(animalDto.CageId);
                currCage.Result.CurrentCapacity++;
                var currCageDto = _mapper.Map<CageDto>(currCage.Result);
                await _cageRepo.UpdateCage(currCage.Result.CageId, currCageDto);
                var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
                return CreatedAtRoute("GetAnimals", animalsDto);
            }
        }

        [HttpPut("update-animal")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateAnimal([FromQuery] string animalId, [FromBody] AnimalDto animalDto)
        {
            var currAnimal = await _animalRepo.GetAnimalById(animalId);
            if (animalDto.Name.Trim().Length == 0 || animalDto.Region.Trim().Length == 0 || animalDto.Behavior.Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else if (currAnimal != null)
            {
                await _animalRepo.UpdateAnimal(animalId, animalDto);
                return Ok("Update Animal Success!");
            }
            return NotFound();
        }

        [HttpGet("areas/cage/animal/area-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimalWithBadHealthStatus(string areaId)
        {
            var animals = await _animalRepo.GetAnimalWithBadHealthStatus(areaId);
            if (!animals.Any())
                return NotFound("Animal is not found!");
            return Ok(_mapper.Map<IEnumerable<AnimalDto>>(animals));
        }
    }
}
