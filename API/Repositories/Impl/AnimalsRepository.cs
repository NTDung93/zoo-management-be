using API.Models;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly ZooManagementContext _context;

        public AnimalsRepository(ZooManagementContext context)
        {
            _context = context;
        }

        public async Task<Animal> GetAnimal(string id)
        {
            return await _context.Animals.FindAsync(id);
        }

        public Task<Animal> GetAnimalById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animals.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<bool> HasAnimal(string id)
        {
            return await _context.Animals.AnyAsync(a => a.Id.Trim().Equals(id));
        }
    }
}
