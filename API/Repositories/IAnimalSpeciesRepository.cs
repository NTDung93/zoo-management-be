using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper.Configuration.Conventions;

namespace API.Repositories
{
    public interface IAnimalSpeciesRepository
    {
        Task<IEnumerable<AnimalSpecies>> GetAnimalSpecies();
        Task<AnimalSpecies> GetAnimalSpecies(int id);
        Task<AnimalSpecies> GetAnimalSpecies(string name);
        Task<IEnumerable<AnimalSpecies>> GetAnimalSpeciesByName(string name);
        Task<bool> CreateAnimalSpecies(AnimalSpecies species);
        Task<bool> UpdateAnimalSpecies(AnimalSpeciesResponse species);
        Task<bool> DeleteAnimalSpecies(int id);
        Task<bool> Save();
        Task<AnimalSpecies> GetSpecyByCageId(string cageId);
    }
}
