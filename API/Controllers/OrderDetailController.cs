using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderDetailController : BaseApiController
    {
        private readonly IOrderDetailRepository _orderDetailRepo;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailRepository orderDetailRepo, IMapper mapper)
        {
            _orderDetailRepo = orderDetailRepo;
            _mapper = mapper;
        }

        [HttpGet("order-details", Name = "GetOrderDetails")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetOrderDetails()
        {
            var orderDetails = await _orderDetailRepo.GetOrderDetails();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!orderDetails.Any())
            {
                return NotFound();
            }
            var orderDetailsDto = _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);
            return Ok(orderDetailsDto);
        }


    }
}
