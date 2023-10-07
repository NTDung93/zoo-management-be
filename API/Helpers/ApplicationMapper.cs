using API.Models.Authen;
using API.Models.Dtos;
using API.Models.Entities;
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
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<FeedingSchedule, FeedingScheduleDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<AnimalSpecy, AnimalSpeciesDto>().ReverseMap();
            CreateMap<EmpProfileModel, Employee>().ReverseMap();

        }
    }
}
