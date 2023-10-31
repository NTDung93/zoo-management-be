using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    public class AreasController : BaseApiController
    {
        private readonly IAreasRepository _areasRepo;
        private readonly ICagesRepository _cageRepo;
        private readonly IMapper _mapper;
        public AreasController(IAreasRepository areaRepo, ICagesRepository cageRepo, IMapper mapper)
        {
            _areasRepo = areaRepo;
            _cageRepo = cageRepo;
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

        [HttpGet("areas-by-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AreaDto>> GetAreasById([FromQuery] string areaId)
        {
            var areas = await _areasRepo.GetAreaById(areaId);
            if (!ModelState.IsValid)
                return BadRequest();
            var areasDto = _mapper.Map<AreaDto>(areas);
            return Ok(areasDto);
        }

        [HttpPost("create-area")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AreaDto>> CreateNewAreas([FromBody] AreaDto areaDto)
        {
            var areaEmp = await _areasRepo.GetAreaByEmpId(areaDto.EmployeeId);
            var areas = await _areasRepo.GetListArea();
            if (areaDto.AreaId.Length > 1 || char.IsDigit(areaDto.AreaId, 0))
            {
                return BadRequest(new ProblemDetails { Title = "AreaId have length is 1 and must to be Upper Alphabet!" });
            }
            else if (areas.SingleOrDefault(tmp => tmp.AreaId.ToLower().Equals(areaDto.AreaId.ToLower())) != null)
            {
                return BadRequest(new ProblemDetails { Title = "AreaId is already exist!" });
            }else if (areaEmp != null)
            {
                return BadRequest(new ProblemDetails { Title = "Area already has a trainer" });
            }
            else
            {
                var area = new Area
                {
                    AreaId = areaDto.AreaId.ToUpper(),
                    AreaName = areaDto.AreaName,
                    EmployeeId = areaDto.EmployeeId,
                    CreatedDate = DateTime.Now,
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
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteAreas([FromQuery] string areaId)
        {
            var listCage = await _cageRepo.GetListCageByAreaId(areaId);
            var currCage = await _areasRepo.GetAreaById(areaId);

            if (listCage.Any())
            {
                return BadRequest(new ProblemDetails { Title = "There are cages in this area!" });
            }
            else if (currCage != null)
            {
                await _areasRepo.DeleteArea(areaId);
                return Ok("Delete Area Success!");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("update-area")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateAreas([FromQuery] string areaId, [FromBody] AreaDto areaDto)
        {
            var areas = await _areasRepo.GetListArea();
            var areaEmp = await _areasRepo.GetAreaById(areaDto.AreaId);
            var areanotEmp = await _areasRepo.GetAreaNotByEmpId(areaEmp.EmployeeId);
            if (areanotEmp.Where(emp => emp.EmployeeId.Equals(areaEmp.EmployeeId)) == null)
            {
                return BadRequest(new ProblemDetails { Title = "Area already has a trainer" });
                
            }
            else
            {
                await _areasRepo.UpdateArea(areaId, areaDto);
                return Ok("Update Area Success!");
            }
            //else if (areas.SingleOrDefault(emp => emp.EmployeeId.Equals(areaDto.EmployeeId)) != null)
            //{
            //    await _areasRepo.UpdateArea(areaId, areaDto);
            //    return Ok("Update Area Success!");
            //}
            //else
            //{
            //    return BadRequest(new ProblemDetails { Title = "Area already has a trainer" });
            //}
        }
    }
}
