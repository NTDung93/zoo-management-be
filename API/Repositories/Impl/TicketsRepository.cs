using API.Models.Data;
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
        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _context.Tickets.OrderBy(x=>x.TicketId).ToListAsync();
        }
    }
}
