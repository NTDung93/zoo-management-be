using API.Model.DTOs;
using API.Model.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Animal, AnimalDto>();
        }
    }
}
