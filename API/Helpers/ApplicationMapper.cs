using API.Models.Authentication;
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
            CreateMap<Employee, EmployeeModel>().ReverseMap();

            CreateMap<AnimalSpecies, AnimalSpeciesRequest>().ReverseMap();
            CreateMap<AnimalSpecies, AnimalSpeciesResponse>().ReverseMap();
        }
    }
}
