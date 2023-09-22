using API.Helpers;
using API.Models;
using API.Models.Dtos;
using API.Models.Entities;
using API.Models.Login;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ZooManagementContext _context;
        private readonly IMapper _mapper;
        
        public EmployeeRepository(ZooManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Authenticate(AccountLogin account)
        {
            var loginAccount = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email.Trim().Equals(account.Email) && 
                e.Password.Trim().Equals(account.Password) && 
                e.IsDeleted == UserRoles.NOT_DELETED);
            return _mapper.Map<EmployeeDto>(loginAccount);
        }

        public async Task<IEnumerable<Employee>> GetStaffAccounts()
        {
            return await _context.Employees.Where(e => e.Role.Trim().Equals(UserRoles.STAFF_ROLE))
                .OrderBy(e => e.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetTrainers()
        {
            return await _context.Employees.Where(e => e.Role.Trim().Equals(UserRoles.TRAINER_ROLE))
                .OrderBy(e => e.Id)
                .ToListAsync();
        }
    }
}
