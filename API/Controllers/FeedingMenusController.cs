using API.Helpers;
using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    public class FeedingMenusController : BaseApiController
    {
        private readonly IFeedingMenuRepository _feedingMenuRepository;
        private readonly IMapper _mapper;

        public FeedingMenusController(IFeedingMenuRepository feedingMenuRepository, 
            IMapper mapper)
        {
            _feedingMenuRepository = feedingMenuRepository;
            _mapper = mapper;
        }

        [HttpGet("feeding-menus")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<FeedingMenuResponse>> GetFeedingMenus()
        {
            var feedingMenus = await _feedingMenuRepository.GetFeedingMenus();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedFeedingMenus = _mapper.Map<IEnumerable<FeedingMenuResponse>>(feedingMenus);
            return Ok(mappedFeedingMenus);
        }

        [HttpGet("feeding-menus/resource-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<FeedingMenuResponse>> GetFeedingMenu(string scheduleNo)
        {
            var feedingMenu = await _feedingMenuRepository.GetFeedingMenu(scheduleNo);
            if (feedingMenu == null) return NotFound("Feeding menu is not found!");
            var mappedFeedingMenu = _mapper.Map<FeedingMenuResponse>(feedingMenu);
            return Ok(mappedFeedingMenu);
        }

        [HttpPost("feeding-menu")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<FeedingMenuResponse>> CreateFeedingMenu([FromBody] FeedingMenuRequest feedingMenu)
        {
            if (string.IsNullOrEmpty(feedingMenu.MenuNo)) 
                return BadRequest(new ProblemDetails
                {
                    Title = "Schedule no is required, " +
                    "the format is SCH[xxx], where x stands for a digit!"
                });
            if (!Regex.IsMatch(feedingMenu.MenuNo, FeedingMenuConstraints.FEEDING_MENU_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid format of schedule no!"
                });
            if (string.IsNullOrEmpty(feedingMenu.MenuName))
                return BadRequest(new ProblemDetails
                {
                    Title = "Schedule name is required!"
                });
            if (string.IsNullOrEmpty(feedingMenu.FoodId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Food is required!"
                });
            if (!Regex.IsMatch(feedingMenu.FoodId, FoodInventoryConstraints.FOOD_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid of food id!"
                });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _feedingMenuRepository.CreateFeedingMenu(
                _mapper.Map<FeedingMenu>(feedingMenu)
                );
            if (!result)
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while creating!"
                });
            return CreatedAtAction(nameof(GetFeedingMenu), new { scheduleNo = feedingMenu.MenuNo }, _mapper.Map<FeedingMenu>(feedingMenu));
        }

        [HttpDelete("feeding-menu/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteFeedingMenu(string scheduleNo)
        {
            if (string.IsNullOrEmpty(scheduleNo)) return BadRequest(new ProblemDetails
            {
                Title = "Schedule no is required!"
            });
            var result = await _feedingMenuRepository.DeleteFeedingMenu(scheduleNo);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while deleting!"
            });
            return NoContent();
        }

        [HttpPut("feeding-menu/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateFeedingMenu(string scheduleNo, [FromBody] FeedingMenuRequest feedingMenu)
        {
            if (!scheduleNo.Trim().ToLower().Equals(feedingMenu.MenuNo.ToLower().Trim()))
                return BadRequest(new ProblemDetails
                {
                    Title = "Schedule no does not match!"
                });
            if (string.IsNullOrEmpty(feedingMenu.MenuName))
                return BadRequest(new ProblemDetails
                {
                    Title = "Schedule name is required!"
                });
            if (string.IsNullOrEmpty(feedingMenu.FoodId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Food is required!"
                });
            if (!Regex.IsMatch(feedingMenu.FoodId, FoodInventoryConstraints.FOOD_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid of food id!"
                });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _feedingMenuRepository.UpdateFeedingMenu(feedingMenu);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while deleting!"
            });
            return NoContent();
        }
    }
}
