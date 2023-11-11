using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IAnimalsRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimalById(string id);
        Task<bool> HasAnimal(string id);
        Task<IEnumerable<Animal>> SearchAnimalsByName(string animalName);
        Task DeleteAnimal(string animalId);
        Task CreateNewAnimal(Animal animal);
        Task UpdateAnimal(string animalId, AnimalDto animalDto);
        Task<IEnumerable<Animal>> GetAnimalByCageId(string id);
        Task<IEnumerable<Animal>> GetAnimalBySpeciesId(int id);

        Task<IEnumerable<Animal>> GetAnimalWithBadHealthStatus(string areaId);
    }
}
