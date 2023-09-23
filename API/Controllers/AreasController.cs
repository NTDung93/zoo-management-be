using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AreasController : BaseApiController
    {
        private readonly IAreasRepository _areasRepo;
        private readonly IMapper _mapper;
        public AreasController(IAreasRepository areaRepo, IMapper mapper)
        {
            _areasRepo = areaRepo;
            _mapper = mapper;
        }
        [HttpGet("load-areas", Name = "GetAreas")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AreaDto>>> GetAreas()
        {
            var areas = await _areasRepo.GetListArea();
            if (!ModelState.IsValid)
                return BadRequest();
            var areasDto = _mapper.Map<IEnumerable<AreaDto>>(areas);
            return Ok(areasDto);
        }

        [HttpPost("create-area")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AreaDto>> CreateNewAreas([FromBody]AreaDto areaDto)
        {
            var areas = await _areasRepo.GetListArea();
            if (areaDto.Id.Length > 1 || char.IsDigit(areaDto.Id, 0))
            {
                return BadRequest(new ProblemDetails { Title = "AreaId have length is 1 and must to be Alphabet!" });
            }else if (areas.SingleOrDefault(tmp => tmp.Id.Equals(areaDto.Id)) != null)
            {
                return BadRequest(new ProblemDetails { Title = "AreaId is Exist!" });
            }else if(areaDto.Name.Trim().Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do Not Allow Empty!" });
            }
            else
            {               
                var area = new Area 
                { 
                    Id = areaDto.Id.ToUpper(),
                    Name = areaDto.Name,
                
                };
                await _areasRepo.CreateNewArea(area);
                areas = await _areasRepo.GetListArea();
                var areasDto = _mapper.Map<IEnumerable<AreaDto>>(areas);
                return CreatedAtRoute("GetAreas", areasDto);
            }  
        }

        [HttpGet("search-area")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AreaDto>>> SearchAreasByName([FromQuery] string areaName)
        {
            if (areaName.Trim().Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else
            {
                var areas = await _areasRepo.SearchAreaByName(areaName.Trim());
                if (!areas.Any())
                {
                    return NotFound();
                }
                else
                {
                    var areasDto = _mapper.Map<IEnumerable<AreaDto>>(areas);
                    return Ok(areasDto);
                }               
            }          
        }

        [HttpDelete("delete-area")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AreaDto>> DeleteAreas([FromQuery] string areaId)
        {
            var currCage = await _areasRepo.GetAreaById(areaId);
            if (currCage != null)
            {
                await _areasRepo.DeleteArea(areaId);
                var areas = await _areasRepo.GetListArea();
                if (!ModelState.IsValid)
                    BadRequest(ModelState);
                return CreatedAtRoute("GetAreas", areas);
            }
            return NotFound();
            
        }

        [HttpPut("update-area")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateAreas([FromQuery] string areaId, [FromBody] AreaDto areaDto)
        {
            var currArea = await _areasRepo.GetAreaById(areaId);
            if (areaDto.Name.Trim().Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else if (currArea != null)
            {
                await _areasRepo.UpdateArea(areaId, areaDto);
                return Ok("Update Area Success!");
            }
            return NotFound();         
        }
    }
}
