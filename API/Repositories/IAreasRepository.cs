﻿using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IAreasRepository
    {
        Task<IEnumerable<Area>> GetListArea();
        Task CreateNewArea(Area area);
        Task<IEnumerable<Area>> SearchAreaByName(string areaName);
        Task<Area> GetAreaById(string areaId);
        Task DeleteArea(string areaId);
        Task UpdateArea(string areaId, AreaDto areaDto);
    }
}
