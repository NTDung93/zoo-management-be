using API.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public interface IAnimalsRepository
    {
        Task<ActionResult<IEnumerable<Animal>>> GetAnimals();
        Task<ActionResult<Animal>> GetAnimal(int id);
    }
}
