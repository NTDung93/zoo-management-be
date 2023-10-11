using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.Entities;
using API.Repositories;
using API.Helpers;
using AutoMapper;

namespace API.Controllers
{
    public class FeedingSchedulesController : BaseApiController
    {
        private readonly IFeedingScheduleRepository _feedingRepo;
        private readonly IMapper _mapper;

        public FeedingSchedulesController(IFeedingScheduleRepository feedingRepo, IMapper mapper)
        {
            this._feedingRepo = feedingRepo;
            this._mapper = mapper;
        }

        [HttpGet("load-schedules", Name = "LoadSchedules")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<FeedingScheduleDto>>> GetFeedingSchedules()
        {
            var feedingSchedule = await _feedingRepo.GetListFeedingSchedule();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!feedingSchedule.Any())
            {
                return NotFound();
            }
            var feedingScheduleDto = _mapper.Map<IEnumerable<FeedingScheduleDto>>(feedingSchedule);
            return Ok(feedingScheduleDto);
        }

        [HttpGet("find-by-schedule-number")]
        public async Task<ActionResult<FeedingScheduleDto>> GetFeedingScheduleById(int id)
        {
            var feedingSchedule = await _feedingRepo.GetFeedingScheduleById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (feedingSchedule == null) return NotFound();
            var feedingScheduleDto = _mapper.Map<FeedingScheduleDto>(feedingSchedule);
            return Ok(feedingScheduleDto);
        }

        //this endpoint is to check whether the animal is fed or not
        [HttpGet("find-by-animal")]
        public async Task<ActionResult<IEnumerable<FeedingScheduleDto>>>GetFeedingScheduleByAnimalName([FromQuery] string name)
        {
            var feedingSchedule = await _feedingRepo.GetFeedingScheduleByAnimalName(name);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!feedingSchedule.Any()) return BadRequest(new ProblemDetails { Title = "This animal is not fed yet!"});
            var feedingScheduleDto = _mapper.Map<IEnumerable<FeedingScheduleDto>>(feedingSchedule);
            return Ok(feedingScheduleDto);
        }

        [HttpGet("find-by-food")]
        public async Task<ActionResult<IEnumerable<FeedingScheduleDto>>> GetFeedingScheduleByFood([FromQuery] string name)
        {
            var feedingSchedule = await _feedingRepo.GetFeedingScheduleByFood(name);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!feedingSchedule.Any()) return BadRequest(new ProblemDetails { Title = "This food is not found or not served yet!" });
            var feedingScheduleDto = _mapper.Map<IEnumerable<FeedingScheduleDto>>(feedingSchedule);
            return Ok(feedingScheduleDto);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFeedingSchedule(int id)
        {
           var feedingSchedule = await _feedingRepo.GetFeedingScheduleById(id);
            if (feedingSchedule == null) return NotFound();
            await _feedingRepo.DeleteSchedule(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schedules = await _feedingRepo.GetListFeedingSchedule();
            return CreatedAtRoute("LoadSchedules", _mapper.Map<IEnumerable<FeedingScheduleDto>>(schedules));
        }

        [HttpPost("post-schedule")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<FeedingScheduleDto>> PostFeedingSchedule([FromBody]FeedingScheduleDto feedingScheduleDto)
        {
            var feedingSchedule = _mapper.Map<FeedingSchedule>(feedingScheduleDto);
            await _feedingRepo.CreateSchedule(feedingSchedule);
            var listSchedule = await _feedingRepo.GetListFeedingSchedule();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("LoadSchedules", _mapper.Map<IEnumerable<FeedingScheduleDto>>(listSchedule));
        }

        [HttpPut("update")]
        public async Task<IActionResult> PutSchedule([FromQuery] int id, [FromBody] FeedingScheduleDto scheduleDto)
        {
            if (id != scheduleDto.ScheduleNo || scheduleDto == null)
            {
                return BadRequest("Invalid schedule data or mismatched IDs.");
            }

            var curSchedule = await _feedingRepo.GetFeedingScheduleById(id);

            if (curSchedule == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _feedingRepo.UpdateSchedule(id, scheduleDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return Ok("Update schedule successfully!");
        }
    }
}
