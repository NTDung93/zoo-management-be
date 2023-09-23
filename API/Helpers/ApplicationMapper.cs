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
            CreateMap<News, NewsDto>().ReverseMap();
        }
    }
}
