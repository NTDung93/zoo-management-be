using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeRequest>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<Cage, CageDto>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();


        }
    }
}
