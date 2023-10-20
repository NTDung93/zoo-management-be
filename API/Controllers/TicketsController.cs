using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TicketsController : BaseApiController  
    {
        private readonly ITicketsRepository _ticketsRepo;
        private readonly IMapper _mapper;

        public TicketsController(ITicketsRepository ticketsRepo, IMapper mapper)
        {
            _ticketsRepo = ticketsRepo;
            _mapper = mapper;
        }

    

        [HttpGet("tickets", Name = "GetTickets")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets()
        {
            var tickets = await _ticketsRepo.GetTickets();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!tickets.Any())
            {
                return NotFound();
            }
            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);
            return Ok(ticketsDto);
        }

        //[HttpGet("get-ticket")]
        //public async Task<ActionResult<TicketDto>> GetTicket([FromQuery] int id)
        //{
        //    var ticket = await _ticketsRepo.GetTicketById(id);
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }
        //    var ticketDto = _mapper.Map<TicketDto>(ticket);
        //    return Ok(ticketDto);
        //}
    }
}
