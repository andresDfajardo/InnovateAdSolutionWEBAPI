using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRevenueController : ControllerBase
    {
        private readonly IProjectRevenueService _projectRevenueService;
        public ProjectRevenueController(IProjectRevenueService projectRevenueService)
        {
            _projectRevenueService = projectRevenueService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectRevenue>>> GetAllProjectRevenues()
        {
            return Ok(await _projectRevenueService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectRevenue>> GetProjectRevenue(int id)
        {
            var ProjectRevenue = await _projectRevenueService.GetProjectRevenue(id);
            if (ProjectRevenue == null)
            {
                return BadRequest("Project Revenue not found");
            }
            return Ok(ProjectRevenue);
        }
        [HttpPost("{projectId}/{revenue_amount}/{date_received}")]
        public async Task<ActionResult<ProjectRevenue>> CreateProjectRevenue(int projectId, int revenue_amount, DateOnly date_received)
        {
            var newProjectRevenue = await _projectRevenueService.CreateProjectRevenue(projectId, revenue_amount, date_received);
            return CreatedAtAction(nameof(GetProjectRevenue), new { newProjectRevenue.id }, newProjectRevenue);
        }
    }
}
