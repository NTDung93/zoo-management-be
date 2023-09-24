using API.Models.Entities;

namespace API.Repositories
{
    public interface IAnimalsRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
    }
}
