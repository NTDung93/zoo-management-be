using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories
{
    public interface ICagesRepository
    {
        Task<IEnumerable<Cage>> GetListCage();
        Task<IEnumerable<Cage>> GetListCageByAreaId(string areaId);
        Task<IEnumerable<Cage>> SearchCageByName(string cageName);
        Task<Cage> GetCageById(string cageId);
        Task DeleteCage(string cageId);
        Task CreateNewCage(Cage cage);
        Task UpdateCage(string cageId, CageDto cageDto);
        Task<bool> HasCage(string cageId);
    }
}
