using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetTrainers();
        Task<Employee> GetTrainer(string id);
        Task<bool> CreateTrainer(Employee trainer);
        Task<bool> UpdateTrainer(EmployeeResponse trainer);
        Task<bool> DeleteTrainer(string id);


        
        Task<bool> HasEmployee(string id);
        Task<bool> Save();
    }
}
