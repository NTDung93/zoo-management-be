 using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;
using System.Text.RegularExpressions;
using API.Helpers;
using API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using NuGet.DependencyResolver;
using System.Collections;
using System.Linq;

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

        [HttpGet("leader-trainers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<LeadTrainerDto>>> GetLeaderTrainers()
        {
            var trainers = await _employeeRepository.GetLeadTrainers();
            List<Employee> leadTrainers = new List<Employee>();
            foreach (var tmp in trainers)
            {
                if(tmp.Area != null)
                {
                    leadTrainers.Add(tmp);
                }
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var leadtrainersDto = _mapper.Map<IEnumerable<LeadTrainerDto>>(leadTrainers);
            return Ok(leadtrainersDto);
        }

        [HttpGet("member-trainers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<LeadTrainerDto>>> GetMemberTrainers()
        {
            var trainers = await _employeeRepository.GetLeadTrainers();
            List<Employee> leadTrainers = new List<Employee>();
            foreach (var tmp in trainers)
            {
                if (tmp.Area == null)
                {
                    leadTrainers.Add(tmp);
                }
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var leadtrainersDto = _mapper.Map<IEnumerable<LeadTrainerDto>>(leadTrainers);
            return Ok(leadtrainersDto);
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

            //var result = await _employeeRepository.CheckDuplicateOfEmail(trainer.Email);
            //if (result)
            //    return BadRequest(new ProblemDetails
            //    {
            //        Title = "Duplicate of email!"
            //    });

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

            var result = await _employeeRepository.CheckDuplicateOfEmail(trainer.Email);
            if (result)
                return BadRequest(new ProblemDetails
                {
                    Title = "Duplicate of email!"
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
            mappedTrainer.CreatedDate = DateTimeOffset.Now;

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

        [HttpGet("trainers/area/resource-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<EmployeeResponse>> GetTrainerOfAnArea(string areaId)
        {
            if (string.IsNullOrEmpty(areaId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Area id is empty!"
                });
            var employees = await _employeeRepository.GetTrainerOfAnArea(areaId);
            if (!employees.Any())
                return NotFound("Employee is not found!");
            var mappedEmployees = employees.Select(e => new EmployeeResponse
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FullName,
            });
            return Ok(mappedEmployees);
        }

        // Staff controller's zone
        [HttpGet("staff-accounts")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetStaffAccounts()
        {
            var staffAccounts = await _employeeRepository.GetStaffAccounts();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedStaff = _mapper.Map<IEnumerable<EmployeeResponse>>(staffAccounts);
            return Ok(mappedStaff);
        }

        [HttpGet("staff/resource-id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<EmployeeResponse>> GetStaff(string id)
        {
            if (!await _employeeRepository.HasEmployee(id)) 
                return NotFound("Staff not found!");
            var staff = await _employeeRepository.GetStaff(id);

            if (staff == null) return NotFound("Staff not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_mapper.Map<EmployeeResponse>(staff));
        }

        [HttpPut("staff/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateStaff(string id, EmployeeResponse staff)
        {
            if (id != staff.EmployeeId)
                return Conflict(new ProblemDetails
                {
                    Title = "Staff id does not match!"
                });

            if (staff == null)
                return BadRequest(new ProblemDetails { Title = "Staff is null!" });

            if (!Regex.IsMatch(staff.PhoneNumber, EmployeeConstraints.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails { Title = "Invalid phone number!" });

            if (!Regex.IsMatch(staff.CitizenId, EmployeeConstraints.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid citizen id format!"
                });

            //var result = await _employeeRepository.CheckDuplicateOfEmail(staff.Email);
            //if (result)
            //    return BadRequest(new ProblemDetails
            //    {
            //        Title = "Duplicate of email!"
            //    });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepository.UpdateStaff(staff))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while updating!"
                });
            return NoContent();
        }

        [HttpPost("staff")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> CreateStaff(EmployeeRequest staff)
        {
            if (staff == null) return BadRequest(new ProblemDetails
            {
                Title = "Staff is empty!"
            });

            if (!Regex.IsMatch(staff.EmployeeId, EmployeeConstraints.EMPLOYEE_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid id format!"
                });

            if (!Regex.IsMatch(staff.CitizenId, EmployeeConstraints.CITIZEN_ID_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid citizen id format!"
                });

            if (!Regex.IsMatch(staff.PhoneNumber, EmployeeConstraints.PHONE_NUMBER_FORMAT))
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid phone number!"
                });

            var result = await _employeeRepository.CheckDuplicateOfEmail(staff.Email);
            if (result)
                return BadRequest(new ProblemDetails
                {
                    Title = "Duplicate of email!"
                });

            if (await _employeeRepository.HasEmployee(staff.EmployeeId))
                return BadRequest(new ProblemDetails
                {
                    Title = "Duplicate of employee id!"
                });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mappedStaff = _mapper.Map<Employee>(staff);
            mappedStaff.Password = EmployeeConstraints.DEFAULT_PASSWORD;
            mappedStaff.Role = EmployeeConstraints.STAFF_ROLE;
            mappedStaff.EmployeeStatus = EmployeeConstraints.NOT_DELETED;
            mappedStaff.CreatedDate = DateTimeOffset.Now;

            if (!await _employeeRepository.CreateStaff(mappedStaff))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while creating!"
                });
            var staffAccounts = await _employeeRepository.GetStaffAccounts();
            return CreatedAtAction("GetStaffAccounts", _mapper.Map<IEnumerable<EmployeeResponse>>(staffAccounts));
        }

        [HttpPut("staff/status/resource-id")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteStaff(string id)
        {
            if (!await _employeeRepository.HasEmployee(id)) 
                return NotFound("Staff not found!");
            if (!await _employeeRepository.DeleteStaff(id))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while deleting staff!"
                });
            return NoContent();
        }
    }
}
