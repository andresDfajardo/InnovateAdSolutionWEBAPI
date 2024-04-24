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
        public async Task<ActionResult<Entities.Task>> CreateTask(int projectId, int employeeId, string description, DateOnly start_date, DateOnly end_date, string status)
        {
            var newTask = await _taskService.CreateTask(projectId, employeeId, description, start_date, end_date, status);
            return CreatedAtAction(nameof(GetTask), new { newTask.id }, newTask);
        }
    }
}
