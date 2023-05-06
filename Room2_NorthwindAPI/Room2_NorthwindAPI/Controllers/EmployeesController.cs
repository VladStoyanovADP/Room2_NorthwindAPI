using Microsoft.AspNetCore.Mvc;
using Room2_NorthwindAPI.Models;
using Room2_NorthwindAPI.Models.DTO;
using Room2_NorthwindAPI.Services;

namespace Room2_NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly INorthwindService<Employee> _employeeService;

        public EmployeesController(
            INorthwindService<Employee> employeeService
            )
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return employees
                .Select(e => Utils.EmployeeToDTO(e))
                .ToList();
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(
            int id,
            [Bind(
            "EmployeeId",
            "LastName",
            "FirstName",
            "Title",
            "TitleOfCourtesy",
            "BirthDate",
            "HireDate",
            "Address",
            "City",
            "PostalCode",
            "Country",
            "ReportsTo",
            "HomePhone"
            )] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var updatedBool = await _employeeService.UpdateAsync(id, employee);

            if (updatedBool == false) return NotFound();

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(
            [Bind(
            "LastName", 
            "FirstName", 
            "Title", 
            "TitleOfCourtesy", 
            "BirthDate", 
            "HireDate", 
            "Address", 
            "City",
            "PostalCode", 
            "Country", 
            "ReportsTo", 
            "HomePhone"
            )] Employee employee)
        {
            var created = await _employeeService.CreateAsync(employee);
            if (!created) return BadRequest();
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = _employeeService.GetAsync(id).Result;
            if (employee == null)
            {
                return NotFound();
            }

            foreach (var order in employee.Orders)
            {
                order.EmployeeId = null;
            }

            var deleted = await _employeeService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
