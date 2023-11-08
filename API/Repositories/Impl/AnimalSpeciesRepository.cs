using API.Models;
using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class AnimalSpeciesRepository : IAnimalSpeciesRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public AnimalSpeciesRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAnimalSpecies(AnimalSpecies species)
        {
            if (species == null) return false;
            species.CreatedDate = DateTimeOffset.Now;
            await _dbContext.AddAsync(species);
            return await Save();
        }

        public async Task<bool> DeleteAnimalSpecies(int id)
        {
            var species = await GetAnimalSpecies(id);
            if (species == null) return false;
            // check whether there is any animal of this species
            var animals = _dbContext.Animals.Where(a => a.SpeciesId == species.SpeciesId).ToList();
            if (animals.Any())
            {
                return false;
            }
            _dbContext.AnimalSpecies.Remove(species);
            return await Save();
        }

        public async Task<IEnumerable<AnimalSpecies>> GetAnimalSpecies()
        {
            return await _dbContext.AnimalSpecies
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        public async Task<AnimalSpecies> GetAnimalSpecies(int id)
        {
            return await _dbContext.AnimalSpecies
                .FindAsync(id);
        }

        public async Task<AnimalSpecies> GetAnimalSpecies(string name)
        {
            return await _dbContext.AnimalSpecies
                .FirstOrDefaultAsync(a => a.SpeciesName.Equals(name.Trim()));
        }

        public async Task<IEnumerable<AnimalSpecies>> GetAnimalSpeciesByName(string name)
        {
            return await _dbContext.AnimalSpecies
                .Where(a => a.SpeciesName.ToLower().Contains(name.Trim().ToLower()))
                .ToListAsync();
        }

        public Task<AnimalSpecies> GetSpecyByCageId(string cageId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateAnimalSpecies(AnimalSpeciesResponse species)
        {
            var existingSpecies = await GetAnimalSpecies(species.SpeciesId);
            if (existingSpecies == null) return false;
            existingSpecies.CreatedDate = DateTimeOffset.Now;
            existingSpecies.SpeciesName = species.SpeciesName;
            _dbContext.Update(existingSpecies);
            return await Save();
        }
    }
}
