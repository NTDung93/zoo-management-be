using API.Models;
using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class AreasRepository : IAreasRepository
    {
        private readonly ZooManagementContext _context;
        public AreasRepository(ZooManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Area>> GetListArea()
        {
            return await _context.Areas.OrderBy(a => a.Id).ToListAsync();
        }
        public async Task CreateNewArea(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Area>> SearchAreaByName(string areaName)
        {
            return await _context.Areas.Where(area => area.Name.ToLower().Contains(areaName.Trim().ToLower())).ToListAsync();
        }
        public async Task<Area> GetAreaById(string areaId)
        {
            return await _context.Areas.SingleOrDefaultAsync(area => area.Id.ToLower().Equals(areaId.Trim().ToLower()));
        }
        public async Task DeleteArea(string areaId)
        {
            var currArea = GetAreaById(areaId);
            _context.Areas.Remove(currArea.Result);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateArea(string areaId, AreaDto areaDto)
        {
            var currArea = GetAreaById(areaId);
            currArea.Result.Name = areaDto.Name;
            await _context.SaveChangesAsync();
        }
    }
}
