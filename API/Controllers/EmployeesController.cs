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
        //[Authorize(Roles = "Staff")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetTrainers()
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var trainers = await _employeeRepo.GetTrainers();
            var mappedTrainer = _mapper.Map<IEnumerable<EmployeeResponse>>(trainers);
            return Ok(mappedTrainer);
        }

        [HttpGet("trainers/resource-id")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Staff")]
        public async Task<ActionResult<EmployeeResponse>> GetTrainer([FromQuery] string id)
        {
            if (!await _employeeRepo.HasTrainer(id))
                return NotFound("Trainer not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trainer = await _employeeRepo.GetTrainer(id);
            var mappedTrainer = _mapper.Map<EmployeeResponse>(trainer);
            return Ok(mappedTrainer);
        }

        [HttpPut("trainer/status/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> DeleteTrainer(string id)
        {
            if (!await _employeeRepo.HasTrainer(id))
                return NotFound("Trainer not found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.DeleteTrainer(id))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while deleting!"
                });
            return NoContent();
        }

        [HttpPost("trainer")]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Staff")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> CreateTrainer([FromBody] EmployeeRequest trainer)
        {
            if (trainer == null) return BadRequest(new ProblemDetails
            {
                Title = "Trainer is empty!"
            });

            // check id format
            if (!Regex.IsMatch(trainer.Id, EmpParams.EMPLOYEE_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "The format of id is E[xxx], where x stands for a digit!"
                });
                        
            // check citizen id format
            if (!Regex.IsMatch(trainer.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "The format of citizen id betweens [9,13] digits!"
                });

            // check duplicate
            if (await _employeeRepo.HasEmployee(trainer.Id))
                return BadRequest(new ProblemDetails
                {
                    Title = "Duplicate of employee Id!"
                });
            
            // check phone number
            if (!Regex.IsMatch(trainer.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid phone number!"
                });

            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var mappedTrainer = _mapper.Map<Employee>(trainer);
             
            mappedTrainer.Password = EmpParams.DEFAULT_PASSWORD;
            mappedTrainer.IsDeleted = EmpParams.NOT_DELETED;
            mappedTrainer.Role = EmpParams.TRAINER_ROLE;

            if (!await _employeeRepo.CreateTrainer(mappedTrainer))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while creating!"
                });
            
            var trainers = await _employeeRepo.GetTrainers();
            return CreatedAtRoute("GetTrainers", _mapper.Map<IEnumerable<EmployeeResponse>>(trainers));
        }

        [HttpPut("trainer/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> UpdateTrainer(string id, [FromBody] EmployeeResponse trainer)
        {
            if (id != trainer.Id)
                return Conflict("Trainer id does not matched!");

            if (trainer == null)
                return BadRequest(new ProblemDetails { Title = "Trainer is null!" });

            if (!EmailValidation.IsValid(trainer.Email))
                return BadRequest(new ProblemDetails { Title = "Invalid email format!" });

            if (!Regex.IsMatch(trainer.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails { Title = "Invalid phone number!" });
            
            if (!Regex.IsMatch(trainer.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid citizen id format!"
                });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.UpdateTrainer(trainer))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while updating!"
                });
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
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetStaffAccounts()
        {
            var staffAccounts = await _employeeRepo.GetStaffAccounts();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var staffAccountsDto = _mapper.Map<IEnumerable<EmployeeResponse>>(staffAccounts);
            return Ok(staffAccountsDto);
        }

        [HttpGet("staff/resource-id")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<EmployeeResponse>> GetStaffAccount(string id)
        {
            if (!await _employeeRepo.HasStaff(id)) return NotFound("Staff not found!");
            var staff = await _employeeRepo.GetStaff(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var staffDto = _mapper.Map<EmployeeResponse>(staff);
            return Ok(staffDto);
        }

        [HttpPost("staff")]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> CreateStaff([FromBody] EmployeeRequest staffDto)
        {
            // default password: 123

            if (staffDto == null) return BadRequest(new ProblemDetails
            {
                Title = "Staff is empty!",
            });

            // check id format
            if (!Regex.IsMatch(staffDto.Id, EmpParams.EMPLOYEE_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "The format of id is E[xxx], where x stands for a digit!"
                });
            
            // check duplicate
            if (await _employeeRepo.HasEmployee(staffDto.Id))
                return BadRequest(new ProblemDetails
                {
                    Title = "Duplicate of employee Id!"
                });

            if (!Regex.IsMatch(staffDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid phone number!"
                });

            if (!Regex.IsMatch(staffDto.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid citizen id format!"
                });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var staff = _mapper.Map<Employee>(staffDto);
            
            staff.Password = EmpParams.DEFAULT_PASSWORD;
            staff.IsDeleted = EmpParams.NOT_DELETED;
            staff.Role = EmpParams.STAFF_ROLE;

            if (!await _employeeRepo.CreateStaff(staff))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while creating!"
                });

            var staffAccounts = await _employeeRepo.GetStaffAccounts();
            return CreatedAtRoute("Staff", _mapper.Map<IEnumerable<EmployeeResponse>>(staffAccounts));
        }

        [HttpPut("staff/status/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStaff([FromQuery] string id)
        {
            if (!await _employeeRepo.HasStaff(id))
                return NotFound("Staff not found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.DeleteStaff(id))
                return BadRequest(new ProblemDetails { Title = "An error occurs while deleting!" });
            return NoContent();
        }

        [HttpPut("staff/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStaff(string id, [FromBody] EmployeeResponse staffDto)
        {
            //if (id != staffDto.Id)
            //    return Conflict("Staff id is not matched!");

            if (staffDto == null)
                return BadRequest(new ProblemDetails { Title = "Staff is null!" });
            
            if (!Regex.IsMatch(staffDto.PhoneNumber, EmpParams.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails { Title = "Invalid phone number!" });

            if (!Regex.IsMatch(staffDto.CitizenId, EmpParams.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails { Title = "Invalid citizen id format!" });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _employeeRepo.UpdateStaff(staffDto))
                return BadRequest(new ProblemDetails { Title = "An error occurs while updating!" });
            return NoContent();
        }
    }
}
