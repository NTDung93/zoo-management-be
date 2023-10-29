using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface ITicketsRepository
    {
        Task CreateTicket(Ticket ticket);
        Task DeleteTicket(string id);
        Task<Ticket> GetTicketById(string id);
        Task<IEnumerable<Ticket>> GetTickets();
        Task UpdateTicket(string id, TicketDto ticketDto);
    }
}
