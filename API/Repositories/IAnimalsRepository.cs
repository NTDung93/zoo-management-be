using API.Models.Entities;

namespace API.Repositories
{
    public interface IAnimalsRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimal(string id);
        Task<bool> HasAnimal(string id);
    }
}
