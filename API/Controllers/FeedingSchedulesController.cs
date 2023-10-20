using API.Helpers;
using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    public class FeedingSchedulesController : BaseApiController
    {
        private readonly IFeedingScheduleRepository _feedingScheduleRepository;
        private readonly IMapper _mapper;
        private readonly string CAGE_ID_FORMAT = @"[A-Z]\\d{4}";

        public FeedingSchedulesController(IFeedingScheduleRepository feedingScheduleRepository, 
            IMapper mapper)
        {
            _feedingScheduleRepository = feedingScheduleRepository;
            _mapper = mapper;
        }

        [HttpGet("feeding-schedules")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FeedingScheduleResponse>>> GetFeedingSchedules()
        {
            var feedingSchedules = await _feedingScheduleRepository.GetFeedingSchedules();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedFeedingSchedules = _mapper.Map<IEnumerable<FeedingScheduleResponse>>(feedingSchedules);
            return Ok(mappedFeedingSchedules);
        }

        [HttpGet("feeding-schedules/resource-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<FeedingScheduleResponse>> GetFeedingSchedule(int no)
        {
            var feedingSchedule = await _feedingScheduleRepository.GetFeedingSchedule(no);
            if (feedingSchedule == null) return NotFound("Feeding schedule is not found!");
            var mappedFeedingSchedule = _mapper.Map<FeedingScheduleResponse>(feedingSchedule);
            return Ok(mappedFeedingSchedule);
        }

        [HttpGet("feeding-schedules/cage/resource-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<FeedingScheduleResponse>> GetFeedingScheduleAtACage(string cageId)
        {
            if (string.IsNullOrEmpty(cageId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Cage id is required!"
                });
            if (!Regex.IsMatch(cageId, CAGE_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid of cage id!"
                });

            var feedingSchedules = await _feedingScheduleRepository.GetFeedingSchedulesByCage(cageId);
            if (!feedingSchedules.Any()) return NotFound("Feeding schedule is not found!");
            var mappedFeedingSchedules = _mapper.Map<IEnumerable<FeedingScheduleResponse>>(feedingSchedules);
            return Ok(mappedFeedingSchedules);
        }

        [HttpGet("feeding-schedules/animal/resource-id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<FeedingScheduleResponse>> GetFeedingScheduleAtAnAnimal(string animalId)
        {
            if (string.IsNullOrEmpty(animalId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Animal id is required!"
                });
            if (!Regex.IsMatch(animalId, AnimalConstraints.ANIMAL_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid of animal id!"
                });

            var feedingSchedules = await _feedingScheduleRepository.GetFeedingSchedulesByAnimal(animalId);
            if (!feedingSchedules.Any()) return NotFound("Feeding schedule is not found!");
            var mappedFeedingSchedules = _mapper.Map<IEnumerable<FeedingScheduleResponse>>(feedingSchedules);
            return Ok(mappedFeedingSchedules);
        }
        /// <summary>
        /// Create a feeding schedule, 
        /// this action is triggered when a chief trainer wants to create the feeding schedule
        /// </summary>
        /// <param name="feedingSchedule"></param>
        /// <returns></returns>
        [HttpPost("feeding-schedule")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<FeedingScheduleResponse>> CreateFeedingSchedule([FromBody] FeedingScheduleRequest feedingSchedule)
        {
            if (string.IsNullOrEmpty(feedingSchedule.MenuNo))
                return BadRequest(new ProblemDetails
                {
                    Title = "Schedule no is required!"  
                });
            if (string.IsNullOrEmpty(feedingSchedule.AnimalId) && string.IsNullOrEmpty(feedingSchedule.CageId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Cage id or Animal id is required!"
                });
            if (feedingSchedule.StartTime <= feedingSchedule.CreatedTime || feedingSchedule.EndTime <= feedingSchedule.CreatedTime)
                return BadRequest(new ProblemDetails
                {
                    Title = "Start time and end time must be greater than created time!"
                });
            if (feedingSchedule.FeedingAmount <= 0)
                return BadRequest(new ProblemDetails
                {
                    Title = "Feeding amount must be a positive number!"
                });
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var mappedFeedingSchedule = _mapper.Map<FeedingSchedule>(feedingSchedule);
            mappedFeedingSchedule.FeedingStatus = FeedingScheduleConstraints.FEEDING_STATUS_PENDING;
            var result = await _feedingScheduleRepository.CreateFeedingSchedule(mappedFeedingSchedule);
            if (!result)
                return BadRequest(new ProblemDetails
                {
                    Title = "Failed to create feeding schedule!"
                });
            return CreatedAtAction(nameof(GetFeedingSchedule), new {no = mappedFeedingSchedule.No}, 
                _mapper.Map<FeedingScheduleResponse>(mappedFeedingSchedule));
        }

        [HttpPut("feeding-schedule/feeding-status/resource-id")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateFeedingScheduleStatus(int no, [FromBody] FeedingScheduleRequest feedingSchedule)
        {
            if (no != feedingSchedule.No)
                return Conflict(new ProblemDetails
                {
                    Title = "The feeding schedule no is not matched!"
                });

            var mappedFeedingSchedule = _mapper.Map<FeedingSchedule>(feedingSchedule);
            var result = await _feedingScheduleRepository.UpdateFeedingScheduleStatus(mappedFeedingSchedule);
            if (!result)
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while updating feeding schedule!"
                });
            return NoContent();
        }
    }
}
