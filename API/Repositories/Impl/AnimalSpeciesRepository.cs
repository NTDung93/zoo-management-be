using API.Models;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class AnimalSpeciesRepository : IAnimalSpeciesRepository
    {
        private readonly ZooManagementContext _context;

        public AnimalSpeciesRepository(ZooManagementContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAnimalSpecies(AnimalSpecy species)
        {
            _context.AnimalSpecies.Add(species);
            return await Save();
        }

        public async Task<bool> DeleteAnimalSpecies(int id)
        {
            var animalSpecies = _context.AnimalSpecies.Find(id);
            if (animalSpecies != null)
                _context.AnimalSpecies.Remove(animalSpecies);
            return await Save();
        }

        public async Task<IEnumerable<AnimalSpecy>> GetSpecies()
        {
            return await _context.AnimalSpecies.OrderBy(ap => ap.Name).ToListAsync();
        }

        public async Task<IEnumerable<AnimalSpecy>> GetSpeciesByCageId(string cageId)
        {
            return await _context.AnimalSpecies
                .Where(ap => ap.CageId.Trim().ToLower().Equals(cageId.Trim().ToLower()))
                .ToListAsync();
        }

        public async Task<AnimalSpecy> GetSpeciesById(int id)
        {
            return await _context.AnimalSpecies.FirstOrDefaultAsync(ap => ap.Id == id);
        }

        public async Task<IEnumerable<AnimalSpecy>> GetSpeciesByName(string name)
        {
            return await _context.AnimalSpecies.OrderBy(ap => ap.Name)
                .Where(ap => ap.Name.Trim().ToLower().Contains(name.Trim().ToLower()))
                .ToListAsync();
        }

        public async Task<bool> HasSpecies(int id)
        {
            return await _context.AnimalSpecies.AnyAsync(ap => ap.Id == id);
        }

        public async Task<bool> Save()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateSpecies(AnimalSpeciesDto species)
        {
            var existingSpecies = await _context.AnimalSpecies.FindAsync(species.Id);

            if (existingSpecies == null)
                return false;
            
            existingSpecies.Name = species.Name;
            existingSpecies.CageId = species.CageId;

            return await Save();
        }
    }
}
