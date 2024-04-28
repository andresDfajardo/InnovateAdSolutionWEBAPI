using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Entities.Task>>> GetAllTasks()
        {
            return Ok(await _taskService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Task>> GetTask(int id)
        {
            var task = await _taskService.GetTask(id);
            if (task == null)
            {
                return BadRequest("Task not found");
            }
            return Ok(task);
        }
        [HttpPost("{projectId}/{employeeId}/{description}/{start_date}/{end_date}/{status}")]
        public async Task<ActionResult<Entities.Task>> CreateTask(int projectId, int employeeId, string description, string start_date, string end_date, string status)
        {
            var newTask = await _taskService.CreateTask(projectId, employeeId, description, start_date, end_date, status);
            return CreatedAtAction(nameof(GetTask), new { newTask.id }, newTask);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Entities.Task>> UpdateTask(int id, int? projectId = null, int? employeeId = null, string? description = null, string? start_date = null, string? end_date = null, string? status = null)
        {
            try
            {
                return Ok(await _taskService.UpdateTask(id, projectId, employeeId, description, start_date, end_date, status));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entities.Task>> DeleteTask(int id)
        {
            var task = await _taskService.DeleteTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }
}
