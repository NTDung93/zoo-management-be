using API.Models;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class CagesRepository : ICagesRepository
    {
        private readonly ZooManagementContext _context;
        public CagesRepository(ZooManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cage>> GetListCage()
        {
            return await _context.Cages.Include(x => x.Area).OrderBy(a => a.Id).ToListAsync();
        }
        public async Task<IEnumerable<Cage>> GetListCageByAreaId(string areaId)
        {
            return await _context.Cages.Include(x => x.Area).OrderBy(a => a.Id).Where(cage => cage.AreaId.Equals(areaId)).ToListAsync();
        }
        public async Task<IEnumerable<Cage>> SearchCageByName(string cageName)
        {
            return await _context.Cages.Include(x => x.Area).Where(cage => cage.Name.ToLower().Contains(cageName.Trim().ToLower())).ToListAsync();
        }
        public async Task<Cage> GetCageById(string cageId)
        {
            return await _context.Cages.FirstOrDefaultAsync(cage => cage.Id.ToLower().Equals(cageId.Trim().ToLower()));
        }
        public async Task DeleteCage(string cageId)
        {
            var currCage = GetCageById(cageId);
            _context.Cages.Remove(currCage.Result);
            await _context.SaveChangesAsync();
        }
        public async Task CreateNewCage(Cage cage)
        {
            await _context.Cages.AddAsync(cage);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCage(string cageId, CageDto cageDto)
        {
            var currCage = GetCageById(cageId);
            currCage.Result.Name = cageDto.Name.Trim();
            currCage.Result.MaxCapacity = cageDto.MaxCapacity;
            currCage.Result.AreaId = cageDto.AreaId;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasCage(string cageId)
        {
            return await _context.Cages.AnyAsync(c => c.Id.ToLower().Equals(cageId.Trim().ToLower()));
        }

        public async Task<Cage> GetCageByIdWithArea(string cageId)
        {
            return await _context.Cages.Include(x=>x.Area).FirstOrDefaultAsync(cage => cage.Id.ToLower().Equals(cageId.Trim().ToLower()));
        }
    }
}
