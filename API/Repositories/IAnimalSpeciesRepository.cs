using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper.Configuration.Conventions;

namespace API.Repositories
{
    public interface IAnimalSpeciesRepository
    {
        Task<IEnumerable<AnimalSpecy>> GetSpecies();
        Task<AnimalSpecy> GetSpeciesById(int id);
        Task<IEnumerable<AnimalSpecy>> GetSpeciesByName(string name);
        Task<IEnumerable<AnimalSpecy>> GetSpeciesByCageId(string cageId);
        Task<bool> CreateAnimalSpecies(AnimalSpecy species);
        Task<bool> DeleteAnimalSpecies(int id);
        Task<bool> UpdateSpecies(AnimalSpeciesDto species);
        Task<bool> HasSpecies(int id);
        Task<bool> Save();
        Task<AnimalSpecy> GetSpecyByCageId(string cageId);
    }
}
