using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Models;
using Room2_NorthwindAPI.Services;

namespace Room2_NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly INorthwindRepository _employeesRepository;
        private readonly INorthwindService _employeeService;

        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = new List<EmployeeDTO>();
            foreach (var item in _employeeService.GetAllAsync().Result)
            {
                employees.Add(Utils.EmployeeToDTO(item));
            }
            return employees;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Utils.EmployeeToDTO(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            
            //_context.Entry(employeeDTO).State = EntityState.Modified;  (idk)

            var employee = await _employeeService.GetAsync(employeeDTO.EmployeeId);


            if (employee is null) return NotFound();

            /*            
            employee.FullName = employeeDTO.FullName ?? employee.FullName;
            employee.Location = employeeDTO.Location ?? employee.Location;
            employee.ContactTitle = employeeDTO.ContactTitle ?? employee.ContactTitle;
            employee.Country = employeeDTO.Country ?? employee.Country;            
             */
            // We stopped here


            bool valid = await _employeeService.UpdateAsync(id, employee);

            if (valid)
            {
                return NoContent();

            }
            else return NotFound();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_context.Employees == null)
          {
              return Problem("Entity set 'NorthwindContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
