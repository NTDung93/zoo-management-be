using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;
using System.Text.RegularExpressions;
using API.Helpers;
using API.Models.Entities;

namespace API.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("trainers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetTrainers()
        {
            var trainers = await _employeeRepository.GetTrainers();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedTrainers = _mapper.Map<IEnumerable<EmployeeResponse>>(trainers);
            return Ok(mappedTrainers);
        }
        
        [HttpGet("trainers/resource-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<EmployeeResponse>> GetTrainer(string id)
        {
            if (!await _employeeRepository.HasEmployee(id)) return NotFound("Trainer not found!");
            var trainer = await _employeeRepository.GetTrainer(id);

            if (trainer == null) return NotFound("Trainer not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_mapper.Map<EmployeeResponse>(trainer));
        }

        [HttpPut("trainer/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateTrainer(string id, EmployeeResponse trainer)
        {
            if (id != trainer.EmployeeId)
                return Conflict(new ProblemDetails
                {
                    Title = "Trainer id does not match!"
                });

            if (trainer == null)
                return BadRequest(new ProblemDetails { Title = "Trainer is null!" });
            
            if (!Regex.IsMatch(trainer.PhoneNumber, EmployeeConstraints.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails { Title = "Invalid phone number!" });

            if (!Regex.IsMatch(trainer.CitizenId, EmployeeConstraints.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid citizen id format!"
                });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepository.UpdateTrainer(trainer))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while updating!"
                });
            return NoContent();
        }

        [HttpPost("trainer")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> CreateTrainer(EmployeeRequest trainer)
        {
            if (trainer == null) return BadRequest(new ProblemDetails
            {
                Title = "Trainer is empty!"
            });

            if (!Regex.IsMatch(trainer.EmployeeId, EmployeeConstraints.EMPLOYEE_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid id format!"
                });

            if (!Regex.IsMatch(trainer.CitizenId, EmployeeConstraints.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid citizen id format!"
                });

            if (!Regex.IsMatch(trainer.PhoneNumber, EmployeeConstraints.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid phone number!"
                });

            if (await _employeeRepository.HasEmployee(trainer.EmployeeId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Duplicate of employee id!"
                });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mappedTrainer = _mapper.Map<Employee>(trainer);
            mappedTrainer.Password = EmployeeConstraints.DEFAULT_PASSWORD;
            mappedTrainer.Role = EmployeeConstraints.TRAINER_ROLE;
            mappedTrainer.EmployeeStatus = EmployeeConstraints.NOT_DELETED;

            if (!await _employeeRepository.CreateTrainer(mappedTrainer))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while creating!"
                });
            var trainers = await _employeeRepository.GetTrainers();
            return CreatedAtAction("GetTrainers", _mapper.Map<IEnumerable<EmployeeResponse>>(trainers));
        }

        [HttpPut("trainer/status/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTrainer(string id)
        {
            if (!await _employeeRepository.HasEmployee(id)) return NotFound("Trainer not found!");
            if (!await _employeeRepository.DeleteTrainer(id))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while deleting trainer!"
                });
            return NoContent();
        }
    }
}
