using API.Helpers;
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

        public async Task<bool> CreateTrainer(Employee trainer)
        {
            if (trainer == null) return false;
            await _dbContext.Employees.AddAsync(trainer);
            return await Save();
        }

        public async Task<bool> DeleteTrainer(string id)
        {
            var trainer = await _dbContext.Employees.FindAsync(id);
            if (trainer == null || !trainer.Role.Equals(EmployeeConstraints.TRAINER_ROLE)) return false;

            trainer.EmployeeStatus = EmployeeConstraints.DELETED;
            _dbContext.Update(trainer);
            return await Save();
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
