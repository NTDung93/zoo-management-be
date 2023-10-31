using API.Models;
using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class AreasRepository : IAreasRepository
    {
        private readonly ZooManagementBackupContext _context;
        public AreasRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Area>> GetListArea()
        {
            return await _context.Areas.Include(x=>x.Employee).OrderByDescending(a => a.CreatedDate).ToListAsync();
        }
        public async Task CreateNewArea(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Area>> SearchAreaByName(string areaName)
        {
            return await _context.Areas.Include(x => x.Employee).Where(area => area.AreaName.ToLower().Contains(areaName.Trim().ToLower())).ToListAsync();
        }
        public async Task<Area> GetAreaById(string areaId)
        {
            return await _context.Areas.Include(x => x.Employee).SingleOrDefaultAsync(area => area.AreaId.ToLower().Equals(areaId.Trim().ToLower()));
        }
        public async Task<Area> GetAreaByEmpId(string empId)
        {
            return await _context.Areas.Include(x => x.Employee).SingleOrDefaultAsync(area => area.EmployeeId.ToLower().Equals(empId.Trim().ToLower()));
        }
        public async Task<IEnumerable<Area>> GetAreaNotByEmpId(string empId)
        {
            return await _context.Areas.Include(x => x.Employee).Where(area => !area.EmployeeId.ToLower().Equals(empId.Trim().ToLower())).ToListAsync();
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
            currArea.Result.AreaName = areaDto.AreaName;
            currArea.Result.EmployeeId = areaDto.EmployeeId;
            currArea.Result.CreatedDate = DateTimeOffset.Now;
            await _context.SaveChangesAsync();
        }
    }
}
