using API.Helpers;
using API.Models.Authentication;
using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public EmployeeRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> Authenticate(LoginModel account)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.Email.Trim().Equals(account.Email) &&
                    e.Password.Trim().Equals(account.Password) &&
                    e.EmployeeStatus == EmployeeConstraints.NOT_DELETED);
        }

        public async Task<bool> CreateStaff(Employee staff)
        {
            if (staff == null) return false;
            await _dbContext.Employees.AddAsync(staff);
            return await Save();
        }

        public async Task<bool> CreateTrainer(Employee trainer)
        {
            if (trainer == null) return false;
            await _dbContext.Employees.AddAsync(trainer);
            return await Save();
        }

        public async Task<bool> DeleteStaff(string id)
        {
            var staff = await _dbContext.Employees.FindAsync(id);
            if (staff == null || !staff.Role.Equals(EmployeeConstraints.STAFF_ROLE)) return false;
            if (staff.EmployeeStatus == EmployeeConstraints.DELETED) return false;

            staff.EmployeeStatus = EmployeeConstraints.DELETED;
            _dbContext.Update(staff);
            return await Save();
        }

        public async Task<bool> DeleteTrainer(string id)
        {
            var trainer = await _dbContext.Employees.FindAsync(id);
            if (trainer == null || !trainer.Role.Equals(EmployeeConstraints.TRAINER_ROLE))
                return false;
            if (trainer.EmployeeStatus == EmployeeConstraints.DELETED) return false;

            trainer.EmployeeStatus = EmployeeConstraints.DELETED;
            _dbContext.Update(trainer);
            return await Save();
        }

        public async Task<Employee> GetStaff(string id)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId.Equals(id.Trim()) && 
                e.Role.Equals(EmployeeConstraints.STAFF_ROLE));
        }

        public async Task<IEnumerable<Employee>> GetStaffAccounts()
        {
            return await _dbContext.Employees
                .OrderBy(e => e.EmployeeId)
                .Where(e => e.Role.Equals(EmployeeConstraints.STAFF_ROLE))
                .ToListAsync();
        }

        public async Task<Employee> GetTrainer(string id)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId.Equals(id.Trim()) && e.Role.Equals(EmployeeConstraints.TRAINER_ROLE));
        }

        public async Task<IEnumerable<Employee>> GetTrainers()
        {
            return await _dbContext.Employees
                .OrderBy(e => e.EmployeeId)
                .Where(e => e.Role.Equals(EmployeeConstraints.TRAINER_ROLE))
                .ToListAsync();
        }

        public async Task<bool> HasEmployee(string id)
        {
            return await _dbContext.Employees
                .AnyAsync(e => e.EmployeeId.Equals(id.Trim()));
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateStaff(EmployeeResponse staff)
        {
            var existingStaff = await _dbContext.Employees
                .FindAsync(staff.EmployeeId);
            if (existingStaff == null || !existingStaff.Role.Equals(EmployeeConstraints.STAFF_ROLE))
                return false;

            existingStaff.FullName = staff.FullName;
            existingStaff.CitizenId = staff.CitizenId;
            existingStaff.Email = staff.Email;
            existingStaff.PhoneNumber = staff.PhoneNumber;
            existingStaff.Image = staff.Image;
            existingStaff.EmployeeStatus = staff.EmployeeStatus;

            _dbContext.Update(existingStaff);
            return await Save();
        }

        public async Task<bool> UpdateTrainer(EmployeeResponse trainer)
        {
            var existingTrainer = await _dbContext.Employees
                .FindAsync(trainer.EmployeeId);
            if (existingTrainer == null || !existingTrainer.Role.Equals(EmployeeConstraints.TRAINER_ROLE)) 
                return false;

            existingTrainer.FullName = trainer.FullName;
            existingTrainer.CitizenId = trainer.CitizenId;
            existingTrainer.Email = trainer.Email;
            existingTrainer.PhoneNumber = trainer.PhoneNumber;
            existingTrainer.Image = trainer.Image;
            existingTrainer.EmployeeStatus = trainer.EmployeeStatus;

            _dbContext.Update(existingTrainer);
            return await Save();
        }
    }
}
