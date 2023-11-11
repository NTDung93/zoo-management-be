using API.Helpers;
using API.Models;
using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace API.Repositories.Impl
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly ZooManagementBackupContext _context;

        public AnimalsRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }

        public async Task<Animal> GetAnimalById(string id)
        {
            return await _context.Animals.Include(x => x.Cage).Include(y => y.Employee).SingleAsync(animal => animal.AnimalId.Equals(id.Trim()));
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animals.Include(x => x.Cage).Include(y => y.Employee).Include(z=>z.AnimalSpecies).OrderByDescending(a => a.CreatedDate).ToListAsync();
        }

        public async Task<bool> HasAnimal(string id)
        {
            return await _context.Animals.AnyAsync(a => a.AnimalId.Trim().Equals(id));
        }
        public async Task<IEnumerable<Animal>> SearchAnimalsByName(string animalName)
        {
            return await _context.Animals.Include(x => x.Cage).Include(y => y.Employee).Where(animal => animal.Name.ToLower().Contains(animalName.Trim().ToLower())).ToListAsync();
        }
        public async Task DeleteAnimal(string animalId)
        {
            var currAnimal = GetAnimalById(animalId);
            _context.Animals.Remove(currAnimal.Result);
            await _context.SaveChangesAsync();
        }
        public async Task CreateNewAnimal(Animal animal)
        {
            animal.CreatedDate = DateTimeOffset.Now;
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnimal(string animalId, AnimalDto animalDto)
        {
            var currAnimal = GetAnimalById(animalId);
            currAnimal.Result.Name = animalDto.Name;
            currAnimal.Result.Region = animalDto.Region;
            currAnimal.Result.Behavior = animalDto.Behavior;
            currAnimal.Result.Gender = animalDto.Gender;
            currAnimal.Result.BirthDate = animalDto.BirthDate;
            currAnimal.Result.Image = animalDto.Image;
            currAnimal.Result.HealthStatus = animalDto.HealthStatus;
            currAnimal.Result.Rarity = animalDto.Rarity;
            currAnimal.Result.IsDeleted = animalDto.IsDeleted;
            currAnimal.Result.EmployeeId = animalDto.EmployeeId;
            currAnimal.Result.CageId = animalDto.CageId;
            currAnimal.Result.SpeciesId = animalDto.SpeciesId;
            currAnimal.Result.CreatedDate = DateTimeOffset.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalByCageId(string id)
        {
            return await _context.Animals.Include(x => x.Cage).Include(y => y.Employee).Include(z => z.AnimalSpecies).Where(animal => animal.CageId.ToLower().Equals(id.ToLower().Trim())).ToListAsync();
        }
        public async Task<IEnumerable<Animal>> GetAnimalBySpeciesId(int id)
        {
            return await _context.Animals.Include(x => x.Cage).Include(y => y.Employee).Include(z => z.AnimalSpecies).Where(animal => animal.SpeciesId == id).ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalWithBadHealthStatus(string areaId)
        {
            return await _context.Animals
                .Include(a => a.Cage)
                .Where(a => a.Cage.Area.AreaId == areaId && a.HealthStatus == AnimalConstraints.HEALTH_STATUS_BAD)
                .ToListAsync();
        }
    }
}
