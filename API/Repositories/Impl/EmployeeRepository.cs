using API.Helpers;
using API.Models;
using API.Models.Authen;
using API.Models.Dtos;
using API.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ZooManagementContext _context;
        private readonly IMapper _mapper;
        
        public EmployeeRepository(ZooManagementContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewRefreshToken(Employee account, string refreshToken)
        {
            var existingAccount = await _context.Employees.FindAsync(account.Id);
            if (existingAccount == null)
                return false;
            
            existingAccount.RefreshToken = refreshToken;

            return await Save();
        }

        public async Task<bool> AddRefreshToken(EmpProfileModel loginAccount, string refreshToken)
        {
            var account = await _context.Employees.FirstOrDefaultAsync(a => a.Email.Equals(loginAccount.Email));
            if (account == null)
                return false;
            
            account.RefreshToken = refreshToken;
            account.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            return await Save();
        }

        public async Task<bool> AssignTrainerWithAnimal(string trainerId, Animal animal)
        {
            // assign a new trainer that manages the animal
            animal.EmpId = trainerId;
            return await Save();    
        }

        public async Task<Employee> Authenticate(LoginModel account)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Email.Trim().Equals(account.Email) &&
                    e.Password.Trim().Equals(account.Password) &&
                    e.IsDeleted == EmpParams.NOT_DELETED);
        }

        public async Task<bool> CreateStaff(Employee staff)
        {
            _context.Employees.Add(staff);
            return await Save();
        }

        public async Task<bool> CreateTrainer(Employee trainer)
        {
            if (trainer.Role.Trim().Equals(EmpParams.TRAINER_ROLE))
            {
                _context.Employees.Add(trainer);
            }
            return await Save();
        }

        public async Task<bool> DeleteStaff(string staffId)
        {
            var staff = _context.Employees.Find(staffId);
            if (staff != null)
            {
                if (staff.IsDeleted == EmpParams.NOT_DELETED)
                {
                    staff.IsDeleted = EmpParams.DELETED;
                    _context.Employees.Update(staff);
                }
            }
            return await Save();
        }

        public async Task<bool> DeleteTrainer(string trainerId)
        {
            var trainer = _context.Employees.Find(trainerId);
            if (trainer != null)
            {
                if (trainer.IsDeleted == EmpParams.NOT_DELETED)
                {
                    trainer.IsDeleted = EmpParams.DELETED;
                    _context.Employees.Update(trainer);
                }
            }
            return await Save();
        }

        public async Task<Employee> GetAccountByEmail(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email.Equals(email));
        }

        public async Task<Employee> GetStaff(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetStaffAccounts()
        {
            return await _context.Employees.Where(e => e.Role.Trim().Equals(EmpParams.STAFF_ROLE))
                .OrderBy(e => e.Id)
                .ToListAsync();
        }

        public async Task<Employee> GetTrainer(string id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id.Trim().ToLower().Equals(id.ToLower().Trim()) && e.Role.Equals(EmpParams.TRAINER_ROLE));
        }

        public async Task<IEnumerable<Employee>> GetTrainers()
        {
            return await _context.Employees.Where(e => e.Role.Trim().Equals(EmpParams.TRAINER_ROLE))
                .OrderBy(e => e.Id)
                .ToListAsync();
        }

        public async Task<bool> HasEmployee(string id)
        {
            return await _context.Employees.AnyAsync(e => e.Id.Trim().ToLower().Equals(id.ToLower().Trim()));
        }

        public async Task<bool> HasStaff(string id)
        {
            return await _context.Employees
                .AnyAsync(e => e.Id.Trim().ToLower().Equals(id.ToLower().Trim()) && e.Role.Equals(EmpParams.STAFF_ROLE));
        }

        public async Task<bool> HasTrainer(string id)
        {
            return await _context.Employees
                .AnyAsync(e => e.Id.Trim().ToLower().Equals(id.ToLower().Trim()) && e.Role.Equals(EmpParams.TRAINER_ROLE));
        }

        public async Task<bool> RevokeRefreshToken(Employee account)
        {
            account.RefreshToken = null;
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateStaff(EmployeeDto staff)
        {
            var existingStaff = await _context.Employees.FindAsync(staff.Id);
            if (existingStaff == null || !existingStaff.Role.Equals(EmpParams.STAFF_ROLE))
                return false;
            
            existingStaff.FullName = staff.FullName;
            existingStaff.Email = staff.Email;
            existingStaff.CitizenId = staff.CitizenId;
            existingStaff.Image = staff.Image;
            existingStaff.PhoneNumber = staff.PhoneNumber;
            existingStaff.Role = EmpParams.STAFF_ROLE;
            existingStaff.IsDeleted = staff.IsDeleted;

            return await Save();
        }

        public async Task<bool> UpdateTrainer(EmployeeDto trainer)
        {
            var existingTrainer = await _context.Employees.FindAsync(trainer.Id);
            if (existingTrainer == null || !existingTrainer.Role.Equals(EmpParams.TRAINER_ROLE))
                return false;
            
            //_mapper.Map(trainer, existingTrainer);

            existingTrainer.FullName = trainer.FullName;
            existingTrainer.Email = trainer.Email;
            existingTrainer.CitizenId = trainer.CitizenId;
            existingTrainer.Image = trainer.Image;
            existingTrainer.PhoneNumber = trainer.PhoneNumber;
            existingTrainer.Role = EmpParams.TRAINER_ROLE;
            existingTrainer.IsDeleted = trainer.IsDeleted;

            return await Save();
        }

        
    }
}
