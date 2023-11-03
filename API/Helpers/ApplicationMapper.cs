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
            CreateMap<Employee, LeadTrainerDto>().ReverseMap();
            CreateMap<AnimalSpecies, AnimalSpeciesRequest>().ReverseMap();
            CreateMap<AnimalSpecies, AnimalSpeciesResponse>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Cage, CageDto>().ReverseMap();
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<AnimalSpecies, AnimalSpeciesDto>().ReverseMap();

            CreateMap<FoodInventory, FoodInventoryRequest>().ReverseMap();
            CreateMap<FoodInventory, FoodInventoryResponse>().ReverseMap();

            CreateMap<ImportHistory, ImportHistoryRequest>().ReverseMap();
            CreateMap<ImportHistory, ImportHistoryResponse>().ReverseMap();

            CreateMap<FeedingMenu, FeedingMenuResponse>().ReverseMap();
            CreateMap<FeedingMenu, FeedingMenuRequest>().ReverseMap();

            CreateMap<FeedingSchedule, FeedingScheduleRequest>().ReverseMap();
            CreateMap<FeedingSchedule, FeedingScheduleResponse>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<TransactionHistory, TransactionHistoryDto>().ReverseMap();
            CreateMap<Certificate, CertificateDto>().ReverseMap();
            CreateMap<EmployeeCertificate, EmployeeCertificateDto>().ReverseMap();
        }
    }
}
