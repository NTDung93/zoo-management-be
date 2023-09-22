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
    }
}
