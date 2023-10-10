using API.Models.Authen;
using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> Authenticate(LoginModel account);
        Task<bool> AddRefreshToken(EmpProfileModel loginAccount, string refreshToken);
        Task<bool> AddNewRefreshToken(Employee account, string refreshToken);
        Task<bool> RevokeRefreshToken(Employee account);
        Task<Employee> GetAccountByEmail(string email);
        /// <summary>
        /// Methods for trainer
        /// </summary>
        Task<IEnumerable<Employee>> GetTrainers();
        Task<Employee> GetTrainer(string id);
        Task<bool> CreateTrainer(Employee trainer);
        Task<bool> UpdateTrainer(EmployeeResponse trainer);
        Task<bool> DeleteTrainer(string trainerId);
        Task<bool> AssignTrainerWithAnimal(string trainerId, Animal animal);
        /// <summary>
        /// Methods for staff
        /// </summary>
        Task<IEnumerable<Employee>> GetStaffAccounts();
        Task<Employee> GetStaff(string id);
        Task<bool> CreateStaff(Employee staff);
        Task<bool> UpdateStaff(EmployeeResponse staff);
        Task<bool> DeleteStaff(string staffId);
        
        Task<bool> HasStaff(string id);
        Task<bool> HasTrainer(string id);
        Task<bool> HasEmployee(string id);
        Task<bool> Save();
    }
}
