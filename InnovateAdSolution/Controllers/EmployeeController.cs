using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var Employee = await _employeeService.GetEmployee(id);
            if (Employee == null)
            {
                return BadRequest("Employee not found");
            }
            return Ok(Employee);
        }
        [HttpPost("{name}/{position}/{department}/{hire_date}/{email}/{employee_number}")]
        public async Task<ActionResult<Employee>> CreateEmployee(string name, string position, string department, string hire_date, string email, string employee_number)
        {
            var newEmployee = await _employeeService.CreateEmployee(name, position, department, hire_date, email, employee_number);
            return CreatedAtAction(nameof(GetEmployee), new { newEmployee.id }, newEmployee);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, string? name = null, string? position = null, string? department = null, string? hire_date = null, string? email = null, string? employee_number = null)
        {
            try
            {
                return Ok(await _employeeService.UpdateEmployee(id, name, position, department, hire_date, email, employee_number));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _employeeService.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
