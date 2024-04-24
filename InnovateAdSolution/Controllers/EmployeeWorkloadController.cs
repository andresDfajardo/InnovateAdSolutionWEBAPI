using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeWorkloadController : ControllerBase
    {
        private readonly IEmployeeWorkloadService _employeeWorkloadService;
        public EmployeeWorkloadController(IEmployeeWorkloadService employeeWorkloadService)
        {
            _employeeWorkloadService = employeeWorkloadService;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeWorkload>>> GetAllEmployeeWorkloads()
        {
            return Ok(await _employeeWorkloadService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeWorkload>> GetEmployeeWorkload(int id)
        {
            var EmployeeWorkload = await _employeeWorkloadService.GetEmployeeWorkload(id);
            if (EmployeeWorkload == null)
            {
                return BadRequest("Employee Workload not found");
            }
            return Ok(EmployeeWorkload);
        }
        [HttpPost("{employeeId}/{projectId}/{hours_worked}/{date}")]
        public async Task<ActionResult<EmployeeWorkload>> CreateEmployeeWorkload(int employeeId, int projectId, int hours_worked, DateOnly date)
        {
            var newEmployeeWorkload = await _employeeWorkloadService.CreateEmployeeWorkload(employeeId, projectId, hours_worked, date);
            return CreatedAtAction(nameof(GetEmployeeWorkload), new { newEmployeeWorkload.id }, newEmployeeWorkload);
        }
        /*[HttpPut("{id}")]
        public async Task<ActionResult<EmployeeWorkload>> UpdateEmployeeWorkload(int id, [FromBody] EmployeeWorkload employeeWorkload)
        {
            try
            {
                return Ok(await _employeeWorkloadService.UpdateEmployeeWorkload(id, employeeWorkload));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }*/
    }
}
