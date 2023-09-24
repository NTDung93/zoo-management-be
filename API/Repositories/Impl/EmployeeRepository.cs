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

        public async Task<bool> AssignTrainerWithAnimal(string trainerId, Animal animal)
        {
            // assign a new trainer that manages the animal
            animal.EmpId = trainerId;
            return await Save();    
        }

        public async Task<EmployeeDto> Authenticate(AccountLogin account)
        {
            var loginAccount = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email.Trim().Equals(account.Email) && 
                e.Password.Trim().Equals(account.Password) && 
                e.IsDeleted == EmpParams.NOT_DELETED);
            return _mapper.Map<EmployeeDto>(loginAccount);
        }

        public async Task<bool> CreateTrainer(Employee trainer)
        {
            if (trainer.Role.Trim().Equals(EmpParams.TRAINER_ROLE))
            {
                _context.Employees.Add(trainer);
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

        public async Task<bool> Save()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateTrainer(EmployeeDto trainer)
        {
            var existingTrainer = await _context.Employees.FindAsync(trainer.Id);
            if (existingTrainer == null)
                return false;
            
            //_mapper.Map(trainer, existingTrainer);

            existingTrainer.FullName = trainer.FullName;
            existingTrainer.Email = trainer.Email;
            existingTrainer.CitizenId = trainer.CitizenId;
            existingTrainer.Image = trainer.Image;
            existingTrainer.PhoneNumber = trainer.PhoneNumber;
            existingTrainer.Role = EmpParams.TRAINER_ROLE;
            existingTrainer.IsDeleted = EmpParams.NOT_DELETED;

            return await Save();
        }

        
    }
}
