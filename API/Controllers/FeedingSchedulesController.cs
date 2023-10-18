using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            // more validation
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
            // more validation
            var feedingSchedules = await _feedingScheduleRepository.GetFeedingSchedulesByAnimal(animalId);
            if (!feedingSchedules.Any()) return NotFound("Feeding schedule is not found!");
            var mappedFeedingSchedules = _mapper.Map<IEnumerable<FeedingScheduleResponse>>(feedingSchedules);
            return Ok(mappedFeedingSchedules);
        }

        [HttpPost("feeding-schedule")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<FeedingScheduleResponse>> CreateFeedingSchedule([FromBody] FeedingScheduleRequest feedingSchedule)
        {
            // start-time < end-time (FE)
            // start-time & end -time > current-time
            // feeding-amount > 0
            if (string.IsNullOrEmpty(feedingSchedule.ScheduleNo))
                return BadRequest(new ProblemDetails
                {
                    Title = "Schedule no is required!"  
                });
            if (string.IsNullOrEmpty(feedingSchedule.AnimalId) && string.IsNullOrEmpty(feedingSchedule.CageId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Cage id or Animal id is required!"
                });
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var mappedFeedingSchedule = _mapper.Map<FeedingSchedule>(feedingSchedule);
            var result = await _feedingScheduleRepository.CreateFeedingSchedule(mappedFeedingSchedule);
            if (!result)
                return BadRequest(new ProblemDetails
                {
                    Title = "Failed to create feeding schedule!"
                });
            return CreatedAtAction(nameof(GetFeedingSchedule), new {no = mappedFeedingSchedule.No}, mappedFeedingSchedule);
        }
    }
}
