using Microsoft.AspNetCore.Mvc;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;

namespace API.Controllers
{

    public class AnimalSpeciesController : BaseApiController
    {
        private readonly IAnimalSpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;
        private readonly ICagesRepository _cagesRepo;

        public AnimalSpeciesController(IAnimalSpeciesRepository speciesRepository, 
            IMapper mapper, 
            ICagesRepository cagesRepo)
        {
            _speciesRepository = speciesRepository;
            _mapper = mapper;
            _cagesRepo = cagesRepo;
        }
        
        [HttpGet("species", Name = "GetSpecies")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesDto>>> GetSpecies()
        {
            var species = await _speciesRepository.GetSpecies();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var speciesDto = _mapper.Map<IEnumerable<AnimalSpeciesDto>>(species);
            return Ok(speciesDto);
        }
        
        [HttpGet("species/species-name")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesDto>>> SearchSpeciesByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Must provide the cageId!");

            var species = await _speciesRepository.GetSpeciesByName(name);
            if (!species.Any())
                return NotFound("Species not found!");
            if (!ModelState.IsValid)
                return BadRequest();

            var speciesDto = _mapper.Map<IEnumerable<AnimalSpeciesDto>>(species);
            return Ok(speciesDto);
        }

        [HttpGet("species/cages/cageId")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesDto>>> SearchSpeciesByCageId([FromQuery] string cageId)
        {
            if (string.IsNullOrWhiteSpace(cageId))
                return BadRequest("Must provide the cageId!");
            var species = await _speciesRepository.GetSpeciesByCageId(cageId);
            if (!species.Any())
                return NotFound("Species not found!");
            if (!ModelState.IsValid)
                return BadRequest();
            var speciesDto = _mapper.Map<IEnumerable<AnimalSpeciesDto>>(species);
            return Ok(speciesDto);
        }
        
        [HttpPut("species/resource-id")]
        public async Task<IActionResult> UpdateSpecies([FromBody] AnimalSpeciesDto species)
        {
            if (species == null) 
                return BadRequest("Species is null!");

            if (!await _cagesRepo.HasCage(species.CageId))
                return NotFound("Cage not found!");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _speciesRepository.UpdateSpecies(species))
                return UnprocessableEntity("An error occurs while updating!");

            return NoContent();
        }

        [HttpPost("species")]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<AnimalSpecy>> CreateSpecies(AnimalSpeciesDto speciesDto)
        {
            if (speciesDto == null)
                return ValidationProblem("Species is nullable!");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var species = _mapper.Map<AnimalSpecy>(speciesDto);
            if (!await _speciesRepository.CreateAnimalSpecies(species))
                return UnprocessableEntity("An error occurs while creating!");

            var listSpecies = await _speciesRepository.GetSpecies();
            return CreatedAtRoute("GetSpecies", _mapper.Map<IEnumerable<AnimalSpeciesDto>>(listSpecies));
        }

        [HttpDelete("species/resource-id")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteSpecies([FromQuery] int id)
        {
            if (!await _speciesRepository.HasSpecies(id))
                return NotFound("Species not found!");
            if (!ModelState.IsValid)
                return BadRequest();
            if (!await _speciesRepository.DeleteAnimalSpecies(id))
                return UnprocessableEntity("An error occurs while deleting!");
            return NoContent();
        }

    }
}
