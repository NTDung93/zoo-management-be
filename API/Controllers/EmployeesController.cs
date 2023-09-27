using Microsoft.AspNetCore.Mvc;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using API.Helpers;
using System.Text.RegularExpressions;

namespace API.Controllers
{

    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly IAnimalsRepository _animalsRepo;
        
        public EmployeesController(IEmployeeRepository employeeRepo, 
            IMapper mapper, 
            IAnimalsRepository animalsRepo)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _animalsRepo = animalsRepo;
        }
        
        [HttpGet("staff-accounts")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStaffAccounts()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var staffAccounts = await _employeeRepo.GetStaffAccounts();
            var staffAccountsDto = _mapper.Map<IEnumerable<EmployeeDto>>(staffAccounts);
            return Ok(staffAccountsDto);
        }

        [HttpGet("trainers")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Staff")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetTrainers()
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var trainers = await _employeeRepo.GetTrainers();
            var trainersDto = _mapper.Map<IEnumerable<EmployeeDto>>(trainers);
            return Ok(trainersDto);
        }

        [HttpGet("trainers/{id}")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Staff")]
        public async Task<ActionResult<EmployeeDto>> GetTrainer(string id)
        {
            if (!await _employeeRepo.HasTrainer(id))
                return NotFound("Trainer not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trainer = await _employeeRepo.GetTrainer(id);
            var trainerDto = _mapper.Map<EmployeeDto>(trainer);
            return Ok(trainerDto);
        }

        [HttpDelete("trainer/{id}")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> DeleteTrainer(string id)
        {
            if (!await _employeeRepo.HasTrainer(id))
                return NotFound("Trainer not found!");

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            if (!await _employeeRepo.DeleteTrainer(id))
                return UnprocessableEntity("An error occurs while deleting!");
            return NoContent();
        }

        [HttpPost("trainer")]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Staff")]
        public async Task<ActionResult<Employee>> CreateTrainer([FromBody] EmployeeDto trainerDto)
        {
            // default password: 123

            if (trainerDto == null) 
                return BadRequest("Trainer is null!");
            
            // check id format
            if (!Regex.IsMatch(trainerDto.Id, EmpParams.EMPLOYEE_ID_FORMAT))
                return ValidationProblem("The format of id is Exxx, x stands for a digit!");
            
            // check email format
            if (!EmailValidation.IsValid(trainerDto.Email))
                return ValidationProblem("Invalid email format!");

            // check duplicate
            if (await _employeeRepo.HasEmployee(trainerDto.Id))
                return Conflict("Duplicate of employee ID!");

            if (!Regex.IsMatch(trainerDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return ValidationProblem("Invalid phone number!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var trainer = _mapper.Map<Employee>(trainerDto);    
            // assign 
            trainer.Password = EmpParams.DEFAULT_PASSWORD;
            trainer.IsDeleted = EmpParams.NOT_DELETED;
            trainer.Role = EmpParams.TRAINER_ROLE;

            if (!await _employeeRepo.CreateTrainer(trainer))
                return UnprocessableEntity("An error occurs while creating!");
            return CreatedAtAction("GetTrainer", new {id = trainer.Id}, trainer);
        }

        [HttpPut("trainer/{id}")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> UpdateTrainer(string id, [FromBody] EmployeeDto trainerDto)
        {
            if (id != trainerDto.Id)
                return Conflict("Trainer id is not matched!");

            if (trainerDto == null)
                return BadRequest("Trainer is null!");

            if (!EmailValidation.IsValid(trainerDto.Email))
                return ValidationProblem("Invalid email format!");

            if (!Regex.IsMatch(trainerDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return ValidationProblem("Invalid phone number!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.UpdateTrainer(trainerDto))
                return UnprocessableEntity("An error occurs while updating!");
            return NoContent();
        }
        
        
        [HttpPut("animal/{animalId}/trainer/{trainerId}")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> AssignTrainerWithAnimal(string trainerId, string animalId)
        {
            if (!await _employeeRepo.HasTrainer(trainerId))
                return NotFound("Trainer not found!");

            if (!await _animalsRepo.HasAnimal(animalId))
                return NotFound("Animal not found!");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var animal = await _animalsRepo.GetAnimalById(animalId);
            
            if (!await _employeeRepo.AssignTrainerWithAnimal(trainerId, animal))
                return UnprocessableEntity("An error occurs while assigning!");

            return Ok("Assign successfully!");
        }

    }
}
