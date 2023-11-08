using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    public class CagesController : BaseApiController
    {
        private readonly ICagesRepository _cagesRepo;
        private readonly IAreasRepository _areasRepo;
        private readonly IAnimalSpeciesRepository _animalSpeciesRepo;
        private readonly IAnimalsRepository _animalsRepo;
        private readonly IMapper _mapper;
        public CagesController(ICagesRepository cagesRepo, IAreasRepository areasRepo, IMapper mapper, IAnimalsRepository animalsRepository, IAnimalSpeciesRepository animalSpeciesRepository)
        {
            _areasRepo = areasRepo;
            _cagesRepo = cagesRepo;
            _mapper = mapper;
            _animalsRepo = animalsRepository;
            _animalSpeciesRepo = animalSpeciesRepository;
        }

        [HttpGet("load-cages", Name = "GetCages")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CageDto>>> GetCages()
        {
            var cages = await _cagesRepo.GetListCage();
            foreach(var cage in cages)
            {
                cage.CurrentCapacity = await _cagesRepo.GetCurrentCapacityInACage(cage.CageId);
            }
            if (!ModelState.IsValid)
                return BadRequest();
            var cagesDto = _mapper.Map<IEnumerable<CageDto>>(cages);
            return Ok(cagesDto);
        }

        [HttpGet("cages-by-areaId")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CageDto>>> GetCagesByAreaId([FromQuery] string areaId)
        {
            var cages = await _cagesRepo.GetListCageByAreaId(areaId);
            foreach (var cage in cages)
            {
                cage.CurrentCapacity = await _cagesRepo.GetCurrentCapacityInACage(cage.CageId);
            }
            if (!ModelState.IsValid)
                return BadRequest();
            var cagesDto = _mapper.Map<IEnumerable<CageDto>>(cages);
            return Ok(cagesDto);
        }

        [HttpGet("get-cage-by-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CageDto>> GetCageById([FromQuery] string id)
        {
            var cage = await _cagesRepo.GetCageByIdWithArea(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (cage == null)
            {
                return NotFound();
            }
            else
            {
                var cageDto = _mapper.Map<CageDto>(cage);
                return Ok(cageDto);
            }
        }

        [HttpGet("search-cages-by-name")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CageDto>>> SearchCagesByName([FromQuery] string cageName)
        {
            if (cageName.Trim().Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else
            {
                var cages = await _cagesRepo.SearchCageByName(cageName.Trim());
                if (!cages.Any())
                {
                    return NotFound();
                }
                else
                {
                    var cagesDto = _mapper.Map<IEnumerable<CageDto>>(cages);
                    return Ok(cagesDto);
                }             
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteCage([FromQuery] string cageId)
        {
            var cage = await _cagesRepo.GetCageById(cageId);
            if (cage == null)
            {
                return BadRequest(new ProblemDetails { Title = "Cage not found!" });
            }
            var hasAnimal = await _animalsRepo.GetAnimalByCageId(cageId);
            if (hasAnimal.Any())
            {
                return BadRequest(new ProblemDetails { Title = "Cage has animal!" });
            }

            await _cagesRepo.DeleteCage(cageId);
            var listCages = await _cagesRepo.GetListCage();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("GetCages", _mapper.Map<IEnumerable<CageDto>>(listCages));
        }

        [HttpPost("create-cage")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CageDto>> CreateNewCages([FromBody] CageDto cageDto)
        {
            string pattern = "[A-Z]\\d{4}";
            var cagebyId = await _cagesRepo.GetCageById(cageDto.CageId);
            var areas = await _areasRepo.GetListArea();
            char tmp = cageDto.CageId.Substring(0, 1)[0];
            if (!Regex.IsMatch(cageDto.CageId, pattern))
            {
                return BadRequest(new ProblemDetails { Title = "CageId have a format [A-Z]{xxxx}!" });
            } 
            else if (areas.SingleOrDefault(area => area.AreaId.Equals(tmp.ToString())) == null)
            {
                return BadRequest(new ProblemDetails { Title = $"{tmp} in {cageDto.CageId} is not exist in ListAreaId" });
            }
            else if (cageDto.CageId.Trim().Length == 0 || cageDto.Name.Trim().Length == 0 || cageDto.AreaId.Length == 0) 
            { 
                return BadRequest(new ProblemDetails { Title = "Do not allow empty!" });
            }
            else if (!tmp.ToString().Equals(cageDto.AreaId))
            {
                return BadRequest(new ProblemDetails { Title = "CageId is not match with AreaId!" });
            }
            else if (cageDto.MaxCapacity < 0)
            {
                return BadRequest(new ProblemDetails { Title = "Capacity greater than 0!" });
            }
            else if (cagebyId != null)
            {
                return BadRequest(new ProblemDetails { Title = "CageId is already exist!" });
            } 
            else if (areas.SingleOrDefault(area => area.AreaId.Equals(cageDto.AreaId)) == null)
            {
                return BadRequest(new ProblemDetails { Title = "AreaId is not Exist!" });
            }
            else
            {
                var cage = _mapper.Map<Cage>(cageDto);
                cage.CreatedDate = DateTimeOffset.Now;
                await _cagesRepo.CreateNewCage(cage);
                var cages = await _cagesRepo.GetListCage();
                var cagesDto = _mapper.Map<IEnumerable<CageDto>>(cages);
                return CreatedAtRoute("GetAreas", cagesDto);
            }
        }

        [HttpPut("update-cage")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateCages([FromQuery] string cageId, [FromBody] CageDto cageDto)
        {
            var areas = await _areasRepo.GetListArea();
            var currCage = await _cagesRepo.GetCageById(cageId);
            char tmp = cageDto.CageId.Substring(0, 1)[0];

            if (cageDto.Name.Trim().Length == 0 || cageDto.AreaId.Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else if (cageDto.MaxCapacity < 0)
            {
                return BadRequest(new ProblemDetails { Title = "Capacity greater than 0!" });
            }
            else if (!tmp.ToString().Equals(cageDto.AreaId))
            {
                return BadRequest(new ProblemDetails { Title = "CageId is not match AreaId!" });
            }
            else if (areas.SingleOrDefault(area => area.AreaId.Equals(cageDto.AreaId)) == null)
            {
                return BadRequest(new ProblemDetails { Title = "AreaId is not Exist!" });
            }
            else if (currCage != null)
            {
                await _cagesRepo.UpdateCage(cageId, cageDto);
                return Ok("Update Cage Success!");
            }
            return NotFound();
        }

        /// <summary>
        /// Controller is used to retrieve the current capacity of a cage
        /// For demonstration purpose
        /// </summary>
        /// <param name="cageId"></param>
        /// <returns></returns>
        [HttpGet("cage/current-capacity")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> GetCurrentCapacityInACage(string cageId)
        {
            var currentCapacity = await _cagesRepo.GetCurrentCapacityInACage(cageId);
            if (currentCapacity < 0) return BadRequest(new ProblemDetails
            {
                Title = "Invalid of capacity!"
            });
            return Ok(currentCapacity);
        }

        [HttpPut("cage/current-capacity")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateCurrentCapacityInACage(string cageId)
        {
            if (string.IsNullOrEmpty(cageId)) return BadRequest(new ProblemDetails
            {
                Title = "Cage id is empty!"
            });
            var result = await _cagesRepo.UpdateCurrentQuantityInACage(cageId);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while updating capacity!"
            });
            return NoContent();
        }
    }
}
