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
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Cage, CageDto>().ReverseMap();
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<AnimalSpecy, AnimalSpeciesDto>().ReverseMap();
            CreateMap<AccountLogin, AdminAccount>().ReverseMap();
        }
    }
}
