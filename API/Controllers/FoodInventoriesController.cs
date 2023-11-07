using API.Helpers;
using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    public class FoodInventoriesController : BaseApiController
    {
        private readonly IFoodInventoryRepository _foodInventoryRepository;
        private readonly IMapper _mapper;

        public FoodInventoriesController(IFoodInventoryRepository foodInventoryRepository, 
            IMapper mapper)
        {
            _foodInventoryRepository = foodInventoryRepository;
            _mapper = mapper;
        }

        [HttpGet("foods")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<FoodInventoryResponse>>> GetFoods()
        {
            var foods = await _foodInventoryRepository.GetFoods();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedFoods = _mapper.Map<IEnumerable<FoodInventoryResponse>>(foods);
            return Ok(mappedFoods);
        }

        [HttpGet("foods/resource-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<FoodInventoryResponse>> GetFood(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest(new ProblemDetails
            {
                Title = "Food's id is empty!"
            });
            var food = await _foodInventoryRepository.GetFood(id);
            if (food == null) return NotFound("Food not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mappedFood = _mapper.Map<FoodInventoryResponse>(food);
            return Ok(mappedFood);
        }

        [HttpPost("food")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<IEnumerable<FoodInventoryResponse>>> CreateFood([FromBody] FoodInventoryRequest food)
        {
            if (string.IsNullOrEmpty(food.FoodId)) return BadRequest(new ProblemDetails
            {
                Title = "Food's id is required!"
            });

            if (!Regex.IsMatch(food.FoodId, FoodInventoryConstraints.FOOD_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid food's id format!"
                });

            if (string.IsNullOrEmpty(food.FoodName)) return BadRequest(new ProblemDetails
            {
                Title = "Food's name is required!"
            });

            var existingFood = await _foodInventoryRepository.GetFood(food.FoodId);
            if (existingFood != null) return BadRequest(new ProblemDetails
            {
                Title = "Food has already existed!"
            });

            var mappedFood = _mapper.Map<FoodInventory>(food);
            mappedFood.InventoryQuantity = FoodInventoryConstraints.DEFAULT_QUANTITY;
            mappedFood.CreatedDate = DateTimeOffset.Now;

            var result = await _foodInventoryRepository.CreateFood(mappedFood);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while creating!"
            });
            
            var foods = await _foodInventoryRepository.GetFoods();
            var mappedFoods = _mapper.Map<IEnumerable<FoodInventoryResponse>>(foods);
            return CreatedAtAction(nameof(GetFoods), mappedFoods);
        }

        [HttpPut("food/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateFood(string id, [FromBody] FoodInventoryRequest food)
        {
            if (id != food.FoodId) return Conflict(new ValidationProblemDetails
            {
                Title = "Food's id does not match!"
            });

            if (string.IsNullOrEmpty(food.FoodName)) return BadRequest(new ProblemDetails
            {
                Title = "Food's name is empty!"
            });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _foodInventoryRepository.UpdateFood(food);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while updating!"
            });
            return NoContent();
        }

        [HttpDelete("food/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteFood(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest(new ProblemDetails
            {
                Title = "Food's id is empty!"
            });
            
            var isExisted = await _foodInventoryRepository.FindFoodInScheduleMenu(id);
            if (isExisted) return BadRequest(new ProblemDetails
            {
                Title = "This food cannot delete!"
            });

            var result = await _foodInventoryRepository.DeleteFood(id);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while deleting!"
            });
            return NoContent();
        }
    }
}
