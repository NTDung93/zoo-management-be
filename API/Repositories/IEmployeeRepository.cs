using API.Models.Authentication;
using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetTrainers();
        Task<IEnumerable<Employee>> GetLeadTrainers();
        Task<Employee> GetTrainer(string id);
        Task<bool> CreateTrainer(Employee trainer);
        Task<bool> UpdateTrainer(EmployeeResponse trainer);
        Task<bool> DeleteTrainer(string id);

        Task<IEnumerable<Employee>> GetStaffAccounts();
        Task<Employee> GetStaff(string id);
        Task<bool> CreateStaff(Employee staff);
        Task<bool> UpdateStaff(EmployeeResponse staff);
        Task<bool> DeleteStaff(string id);
        
        Task<bool> HasEmployee(string id);
        Task<bool> Save();

        Task<bool> CheckDuplicateOfEmail(string email);
        Task<Employee> Authenticate(LoginModel account);

        Task<IEnumerable<Employee>> GetTrainerOfAnArea(string areaId);
    }
}
