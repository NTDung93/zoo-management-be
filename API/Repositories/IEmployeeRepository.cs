using API.Models.Dtos;
using API.Models.Entities;
using API.Models.Login;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDto> Authenticate(AccountLogin account);
        Task<IEnumerable<Employee>> GetStaffAccounts();
        Task<IEnumerable<Employee>> GetTrainers();
        Task<Employee> GetTrainer(string id);
        Task<bool> CreateTrainer(Employee trainer);
        Task<bool> UpdateTrainer(EmployeeDto trainer);
        Task<bool> DeleteTrainer(string trainerId);
        Task<bool> AssignTrainerWithAnimal(string trainerId, Animal animal);
        Task<bool> HasStaff(string id);
        Task<bool> HasTrainer(string id);
        Task<bool> HasEmployee(string id);
        Task<bool> Save();
    }
}
