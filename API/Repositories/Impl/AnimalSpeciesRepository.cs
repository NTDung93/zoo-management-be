using API.Models;
using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class AnimalSpeciesRepository : IAnimalSpeciesRepository
    {
        private readonly ZooManagementBackupContext _context;

        public AnimalSpeciesRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAnimalSpecies(AnimalSpecies species)
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

        public async Task<IEnumerable<AnimalSpecies>> GetSpecies()
        {
            return await _context.AnimalSpecies
                .Include(ap => ap.News)
                .OrderBy(ap => ap.SpeciesName)
                .ToListAsync();
        }

        public async Task<AnimalSpecies> GetSpeciesById(int id)
        {
            return await _context.AnimalSpecies.FirstOrDefaultAsync(ap => ap.SpeciesId == id);
        }

        public async Task<IEnumerable<AnimalSpecies>> GetSpeciesByName(string name)
        {
            return await _context.AnimalSpecies
                .Include(ap => ap.News)
                .OrderBy(ap => ap.SpeciesName)
                .Where(ap => ap.SpeciesName.Trim().ToLower().Contains(name.Trim().ToLower()))
                .ToListAsync();
        }

        public async Task<bool> HasSpecies(int id)
        {
            return await _context.AnimalSpecies.AnyAsync(ap => ap.SpeciesId == id);
        }

        public async Task<bool> Save()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateSpecies(AnimalSpeciesDto species)
        {
            var existingSpecies = await _context.AnimalSpecies.FindAsync(species.SpeciesId);

            if (existingSpecies == null)
                return false;
            
            existingSpecies.SpeciesName = species.SpeciesName;

            return await Save();
        }
    }
}
