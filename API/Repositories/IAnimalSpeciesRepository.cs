﻿using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper.Configuration.Conventions;

namespace API.Repositories
{
    public interface IAnimalSpeciesRepository
    {
        Task<IEnumerable<AnimalSpecies>> GetSpecies();
        Task<AnimalSpecies> GetSpeciesById(int id);
        Task<IEnumerable<AnimalSpecies>> GetSpeciesByName(string name);
        Task<bool> CreateAnimalSpecies(AnimalSpecies species);
        Task<bool> DeleteAnimalSpecies(int id);
        Task<bool> UpdateSpecies(AnimalSpeciesDto species);
        Task<bool> HasSpecies(int id);
        Task<bool> Save();
    }
}
