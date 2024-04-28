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
        public async Task<ActionResult<Project>> CreateProject(string project_name, int clientId, string start_date, string end_date, int budget, string status)
        {
            var newProject = await _projectService.CreateProject(project_name, clientId, start_date, end_date, budget, status);
            return CreatedAtAction(nameof(GetProject), new { newProject.id }, newProject);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, string? project_name = null, int? clientId = null, string? start_date = null, string? end_date = null, int? budget = null, string? status = null)
        {
            try
            {
                return Ok(await _projectService.UpdateProject(id, project_name, clientId, start_date, end_date, budget, status));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
