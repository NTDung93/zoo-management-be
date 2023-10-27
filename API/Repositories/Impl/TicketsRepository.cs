using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly ZooManagementBackupContext _context;
        public TicketsRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }

        public async Task CreateTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicket(string id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x=>x.TicketId == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<Ticket> GetTicketById(string id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x=>x.TicketId == id);
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _context.Tickets.OrderBy(x=>x.TicketId).ToListAsync();
        }

        public async Task UpdateTicket(string id, TicketDto ticketDto)
        {
            var currentNews = GetTicketById(id);
            currentNews.Result.Type = ticketDto.Type;
            currentNews.Result.UnitPrice = ticketDto.UnitPrice;
            currentNews.Result.Image = ticketDto.Image;
            currentNews.Result.Description = ticketDto.Description;
            await _context.SaveChangesAsync();
        }
    }
}
