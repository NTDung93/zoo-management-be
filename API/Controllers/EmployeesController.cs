using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
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
        [Authorize(Roles = "Staff")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetTrainers()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trainers = await _employeeRepo.GetTrainers();
            var trainersDto = _mapper.Map<IEnumerable<EmployeeDto>>(trainers);
            return Ok(trainersDto);
        }
        // GET: api/Employees/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> GetEmployee(string id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return employee;
        //}

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployee(string id, Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (EmployeeExists(employee.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        //}

        // DELETE: api/Employees/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
