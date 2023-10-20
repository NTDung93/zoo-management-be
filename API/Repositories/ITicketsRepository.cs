using API.Models.Entities;

namespace API.Repositories
{
    public interface ITicketsRepository
    {
        Task<IEnumerable<Ticket>> GetTickets();
    }
}
