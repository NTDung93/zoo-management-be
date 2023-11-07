using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("get-ticket")]
        public async Task<ActionResult<TicketDto>> GetTicket([FromQuery] string id)
        {
            var ticket = await _ticketsRepo.GetTicketById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (ticket == null)
            {
                return NotFound();
            }
            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return Ok(ticketDto);
        }

        [HttpPost("create")]
        public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketsRepo.CreateTicket(ticket);
            var listTickets = await _ticketsRepo.GetTickets();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("GetTickets", _mapper.Map<IEnumerable<TicketDto>>(listTickets));
        }

        [HttpPut("update")]
        public async Task<IActionResult> PutTickets([FromQuery] string id, [FromBody] TicketDto ticketDto)
        {
            if (id != ticketDto.TicketId || ticketDto == null)
            {
                return BadRequest("Invalid news data or mismatched IDs.");
            }

            var currentNews = await _ticketsRepo.GetTicketById(id);

            if (currentNews == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _ticketsRepo.UpdateTicket(id, ticketDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return Ok("Update tickets successfully.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTicket([FromQuery] string id)
        {
            var news = await _ticketsRepo.GetTicketById(id);
            if (news == null)
            {
                return BadRequest(new ProblemDetails { Title = "Ticket not found!" });
            }
            await _ticketsRepo.DeleteTicket(id);
            var listTickets = await _ticketsRepo.GetTickets();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("GetTickets", _mapper.Map<IEnumerable<TicketDto>>(listTickets));
        }
    }
}
