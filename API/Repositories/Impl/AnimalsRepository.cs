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

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animals.OrderBy(a => a.Id).ToListAsync();
        }
    }
}
