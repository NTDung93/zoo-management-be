using API.Model.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository.Impl
{
    public class AnimalsRepository : IAnimalsRepository
    {
        public Task<ActionResult<Animal>> GetAnimal(int id) => AnimalsService.Instance.GetAnimal(id);

        public Task<ActionResult<IEnumerable<Animal>>> GetAnimals() => AnimalsService.Instance.GetAnimals();
    }
}
