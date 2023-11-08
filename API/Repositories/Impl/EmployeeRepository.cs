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
                .Where(e => e.Email.Trim().Equals(account.Email) &&
                    e.Password.Trim().Equals(account.Password) &&
                    e.EmployeeStatus == EmployeeConstraints.NOT_DELETED)
                .Include(e => e.Area)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CheckDuplicateOfEmail(string email)
        {
            var result = await _dbContext.Employees
                .AnyAsync(e => e.Email.ToLower() == email.ToLower());
            return result;
        }

        public async Task<bool> CreateStaff(Employee staff)
        {
            if (staff == null) return false;
            staff.CreatedDate = DateTimeOffset.Now;
            await _dbContext.Employees.AddAsync(staff);
            return await Save();
        }

        public async Task<bool> CreateTrainer(Employee trainer)
        {
            if (trainer == null) return false;
            trainer.CreatedDate = DateTimeOffset.Now;
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

        public async Task<IEnumerable<Employee>> GetTrainerOfAnArea(string areaId)
        {
            var result = await _dbContext.Employees
                .Join(
                    _dbContext.Animals,
                    e => e.EmployeeId,
                    a => a.EmployeeId,
                    (e, a) => new { e, a }
                )
                .Join(
                    _dbContext.Cages,
                    ea => ea.a.CageId,
                    c => c.CageId,
                    (ea, c) => new { ea.a, ea.e, c }
                )
                .Join(
                    _dbContext.Areas,
                    eac => eac.c.AreaId,
                    ar => ar.AreaId,
                    (eac, ar) => new { eac.e, ar }
                )
                .Where(x => x.ar.AreaId.ToLower() == areaId.ToLower())
                .Select(x => x.e)
                //.Distinct()
                .ToListAsync();
            var distinctResult = result.GroupBy(e => e.EmployeeId)
                .Select(g => g.First());
            return distinctResult;
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
                .OrderByDescending(e => e.CreatedDate)
                .Where(e => e.Role.Equals(EmployeeConstraints.STAFF_ROLE))
                .ToListAsync();
        }

        public async Task<Employee> GetTrainer(string id)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId.Equals(id.Trim()) && e.Role.Equals(EmployeeConstraints.TRAINER_ROLE));
        }

        //public async Task<IEnumerable<Employee>> GetTrainerOfAnArea(string areaId)
        //{
        //    return await _dbContext.Employees
        //        .Include(e => e.Animals)
        //        .ThenInclude(a => a.Cage)
        //        .Where(e => e.Animals.Any(a => a.Cage.AreaId == areaId))
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<Employee>> GetTrainers()
        {
            return await _dbContext.Employees
                .OrderByDescending(e => e.CreatedDate)
                .Where(e => e.Role.Equals(EmployeeConstraints.TRAINER_ROLE))
                .ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetLeadTrainers()
        {
            return await _dbContext.Employees.Include(x => x.Area)
                .OrderByDescending(e => e.CreatedDate).Where(e => e.Role.Equals(EmployeeConstraints.TRAINER_ROLE)).ToListAsync();        
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
            existingStaff.CreatedDate = DateTimeOffset.Now;
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
            //existingTrainer.Email = trainer.Email;
            existingTrainer.PhoneNumber = trainer.PhoneNumber;
            existingTrainer.Image = trainer.Image;
            existingTrainer.EmployeeStatus = trainer.EmployeeStatus;
            existingTrainer.CreatedDate = DateTimeOffset.Now;
            _dbContext.Update(existingTrainer);
            return await Save();
        }
    }
}
