using API.Model.Entities;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AnimalsService
    {
        private AnimalsService() { }
        private static AnimalsService instance;
        private static readonly object instanceLock = new object();
        public static AnimalsService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AnimalsService();
                    }
                    return instance;
                }
            }
        }

        private readonly ZooContext _context;

        public AnimalsService(ZooContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            return await _context.Animals.FindAsync(id);
        }
    }
}
