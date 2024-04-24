using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProject()
        {
            return Ok(await _projectService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var Project = await _projectService.GetProject(id);
            if (Project == null)
            {
                return BadRequest("Project not found");
            }
            return Ok(Project);
        }
        [HttpPost("{project_name}/{clientId}/{start_date}/{end_date}/{budget}/{status}")]
        public async Task<ActionResult<Project>> CreateProject(string project_name, int clientId, DateOnly start_date, DateOnly end_date, int budget, string status)
        {
            var newProject = await _projectService.CreateProject(project_name, clientId, start_date, end_date, budget, status);
            return CreatedAtAction(nameof(GetProject), new { newProject.id }, newProject);
        }
    }
}
