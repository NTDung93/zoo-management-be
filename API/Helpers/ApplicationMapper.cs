using API.Models.Dtos;
using API.Models.Entities;
using API.Models.Login;
using AutoMapper;

namespace API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            // mapping between entities stored in Models and Dtos
            // using ReverseMap() to map both ways
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<AnimalSpecy, AnimalSpeciesDto>().ReverseMap();
            CreateMap<AccountLogin, AdminAccount>().ReverseMap();
        }
    }
}
