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
        private readonly IMapper _mapper;
        public CagesController(ICagesRepository cagesRepo, IAreasRepository areasRepo, IMapper mapper)
        {
            _areasRepo = areasRepo;
            _cagesRepo = cagesRepo;
            _mapper = mapper;
        }

        [HttpGet("load-cages", Name = "GetCages")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CageDto>>> GetCages()
        {
            var cages = await _cagesRepo.GetListCage();
            if (!ModelState.IsValid)
                return BadRequest();
            var cagesDto = _mapper.Map<IEnumerable<CageDto>>(cages);
            return Ok(cagesDto);
        }

        [HttpGet("load-cages-by-areaId")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CageDto>>> GetCagesByAreaId([FromQuery] string areaId)
        {
            var cages = await _cagesRepo.GetListCageByAreaId(areaId);
            if (!ModelState.IsValid)
                return BadRequest();
            var cagesDto = _mapper.Map<IEnumerable<CageDto>>(cages);
            return Ok(cagesDto);
        }

        [HttpGet("search-cages")]
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

        [HttpDelete("delete-cage")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CageDto>> DeleteCages([FromQuery] string cageId)
        {
            var currCage = await _cagesRepo.GetCageById(cageId);
            if(currCage != null)
            {
                await _cagesRepo.DeleteCage(cageId);
                var cages = await _cagesRepo.GetListCage();
                if (!ModelState.IsValid)
                    BadRequest(ModelState);
                return CreatedAtRoute("GetCages", cages);
            }
            return NotFound();
        }

        [HttpPost("create-cage")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CageDto>> CreateNewCages([FromBody] CageDto cageDto)
        {
            string pattern = "[A-Z]\\d{4}";
            var cagebyId = await _cagesRepo.GetCageById(cageDto.Id);
            var areas = await _areasRepo.GetListArea();
            char tmp = cageDto.Id.Substring(0, 1)[0];
            if (!Regex.IsMatch(cageDto.Id, pattern))
            {
                return BadRequest(new ProblemDetails { Title = "CageId have a format [A-Z]{xxxx}!" });
            } 
            else if (areas.SingleOrDefault(area => area.Id.Equals(tmp)) == null)
            {
                return BadRequest(new ProblemDetails { Title = $"{tmp} in {cageDto.Id} is not exist in ListAreaId" });
            }
            else if (cageDto.Id.Trim().Length == 0 || cageDto.Name.Trim().Length == 0 || cageDto.AreaId.Length == 0) 
            { 
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            } 
            else if (cageDto.MaxCapacity < 0 || cageDto.MaxCapacity > 10)
            {
                return BadRequest(new ProblemDetails { Title = "Capacity greater than 10!" });
            }
            else if (cagebyId != null)
            {
                return BadRequest(new ProblemDetails { Title = "CageId is Exist!" });
            } 
            else if (areas.SingleOrDefault(area => area.Id.Equals(cageDto.AreaId)) == null)
            {
                return BadRequest(new ProblemDetails { Title = "AreaId is not Exist!" });
            }
            else
            {
                var cage = _mapper.Map<Cage>(cageDto);
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
            if (cageDto.Id.Trim().Length == 0 || cageDto.Name.Trim().Length == 0 || cageDto.AreaId.Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else if (cageDto.MaxCapacity < 0 || cageDto.MaxCapacity > 10)
            {
                return BadRequest(new ProblemDetails { Title = "Capacity greater than 10!" });
            }
            else if (areas.SingleOrDefault(area => area.Id.Equals(cageDto.AreaId)) == null)
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
    }
}
