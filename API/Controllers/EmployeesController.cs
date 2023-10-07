using Microsoft.AspNetCore.Mvc;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;
using API.Helpers;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

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
        
        [HttpGet("trainers", Name = "GetTrainers")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Staff")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetTrainers()
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var trainers = await _employeeRepo.GetTrainers();
            var trainersDto = _mapper.Map<IEnumerable<EmployeeDto>>(trainers);
            return Ok(trainersDto);
        }

        [HttpGet("trainers/resource-id")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Staff")]
        public async Task<ActionResult<EmployeeDto>> GetTrainer([FromQuery] string id)
        {
            if (!await _employeeRepo.HasTrainer(id))
                return NotFound("Trainer not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trainer = await _employeeRepo.GetTrainer(id);
            var trainerDto = _mapper.Map<EmployeeDto>(trainer);
            return Ok(trainerDto);
        }

        [HttpDelete("trainer/resource-id")]
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
                return ValidationProblem("The format of id is E[xxx], where x stands for a digit!");
            
            // check email format
            if (!EmailValidation.IsValid(trainerDto.Email))
                return ValidationProblem("Invalid email format!");
            
            // check citizen id format
            if (!Regex.IsMatch(trainerDto.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return ValidationProblem("Invalid citizen id format, it must contain [9,13] digits!");

            // check duplicate
            if (await _employeeRepo.HasEmployee(trainerDto.Id))
                return ValidationProblem("Duplicate of employee Id!");
            
            // check phone number
            if (!Regex.IsMatch(trainerDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return ValidationProblem("Invalid phone number, it must contains [10,12] digits!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var trainer = _mapper.Map<Employee>(trainerDto);    
            // assign 
            trainer.Password = EmpParams.DEFAULT_PASSWORD;
            trainer.IsDeleted = EmpParams.NOT_DELETED;
            trainer.Role = EmpParams.TRAINER_ROLE;

            if (!await _employeeRepo.CreateTrainer(trainer))
                return UnprocessableEntity("An error occurs while creating!");
            
            var trainers = await _employeeRepo.GetTrainers();
            return CreatedAtRoute("GetTrainers", _mapper.Map<IEnumerable<EmployeeDto>>(trainers));
        }

        [HttpPut("trainer/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> UpdateTrainer(string id, [FromBody] EmployeeDto trainerDto)
        {
            if (id != trainerDto.Id)
                return Conflict("Trainer id does not matched!");

            if (trainerDto == null)
                return BadRequest("Trainer is null!");

            if (!EmailValidation.IsValid(trainerDto.Email))
                return ValidationProblem("Invalid email format!");

            if (!Regex.IsMatch(trainerDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return ValidationProblem("Invalid phone number, it must contains [10,12] digits!");

            if (!Regex.IsMatch(trainerDto.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return ValidationProblem("Invalid citizen id format, it must contain [9,13] digits!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.UpdateTrainer(trainerDto))
                return UnprocessableEntity("An error occurs while updating!");
            return NoContent();
        }
        
        
        [HttpPut("assign-trainer-with-animal")]
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


        [HttpGet("staff-accounts", Name = "Staff")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStaffAccounts()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var staffAccounts = await _employeeRepo.GetStaffAccounts();
            var staffAccountsDto = _mapper.Map<IEnumerable<EmployeeDto>>(staffAccounts);
            return Ok(staffAccountsDto);
        }

        [HttpGet("staff/resource-id")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStaffAccount(string id)
        {
            if (!await _employeeRepo.HasStaff(id))
                return NotFound("Staff not found!");
            var staff = await _employeeRepo.GetStaff(id);
            var staffDto = _mapper.Map<EmployeeDto>(staff);
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(staffDto);
        }

        [HttpPost("staff")]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Employee>> CreateStaff([FromBody] EmployeeDto staffDto)
        {
            // default password: 123

            if (staffDto == null)
                return BadRequest("Staff is null!");

            // check id format
            if (!Regex.IsMatch(staffDto.Id, EmpParams.EMPLOYEE_ID_FORMAT))
                return ValidationProblem("The format of id is Exxx, x stands for a digit!");

            // check email format
            if (!EmailValidation.IsValid(staffDto.Email))
                return ValidationProblem("Invalid email format!");

            // check duplicate
            if (await _employeeRepo.HasEmployee(staffDto.Id))
                return BadRequest("Duplicate of employee ID!");

            if (!Regex.IsMatch(staffDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return ValidationProblem("Invalid phone number!");

            if (!Regex.IsMatch(staffDto.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return ValidationProblem("Invalid citizen id format!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var staff = _mapper.Map<Employee>(staffDto);
            
            staff.Password = EmpParams.DEFAULT_PASSWORD;
            staff.IsDeleted = EmpParams.NOT_DELETED;
            staff.Role = EmpParams.STAFF_ROLE;

            if (!await _employeeRepo.CreateStaff(staff))
                return UnprocessableEntity("An error occurs while creating!");

            var staffAccounts = await _employeeRepo.GetStaffAccounts();
            return CreatedAtRoute("Staff", _mapper.Map<IEnumerable<EmployeeDto>>(staffAccounts));
        }

        [HttpDelete("staff/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStaff([FromQuery] string id)
        {
            if (!await _employeeRepo.HasStaff(id))
                return NotFound("Staff not found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.DeleteStaff(id))
                return UnprocessableEntity("An error occurs while deleting!");
            return NoContent();
        }

        [HttpPut("staff/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStaff(string id, [FromBody] EmployeeDto staffDto)
        {
            if (id != staffDto.Id)
                return Conflict("Staff id is not matched!");

            if (staffDto == null)
                return BadRequest("Staff is null!");

            if (!EmailValidation.IsValid(staffDto.Email))
                return ValidationProblem("Invalid email format!");

            if (!Regex.IsMatch(staffDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return ValidationProblem("Invalid phone number!");

            if (!Regex.IsMatch(staffDto.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return ValidationProblem("Invalid citizen id format!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.UpdateStaff(staffDto))
                return UnprocessableEntity("An error occurs while updating!");
            return NoContent();
        }
    }
}
