using InnovateAd.Entities;
using InnovateAd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovateAd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectExpenseController : ControllerBase
    {
        private readonly IProjectExpenseService _projectExpenseService;
        public ProjectExpenseController(IProjectExpenseService projectExpenseService)
        {
            _projectExpenseService = projectExpenseService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectExpense>>> GetAllProjectExpenses()
        {
            return Ok(await _projectExpenseService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectExpense>> GetProjectExpense(int id)
        {
            var ProjectExpense = await _projectExpenseService.GetProjectExpense(id);
            if (ProjectExpense == null)
            {
                return BadRequest("Project Expense not found");
            }
            return Ok(ProjectExpense);
        }
        [HttpPost("{projectId}/{expense_type}/{expense_amount}/{expense_date}")]
        public async Task<ActionResult<ProjectExpense>> CreateProjectExpense(int projectId, string expense_type, int expense_amount, string expense_date)
        {
            var newProjectExpense = await _projectExpenseService.CreateProjectExpense(projectId, expense_type, expense_amount, expense_date);
            return CreatedAtAction(nameof(GetProjectExpense), new { newProjectExpense.id }, newProjectExpense);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectExpense>> UpdateProjectExpense(int id, int? projectId = null, string? expense_type = null, int? expense_amount = null, string? expense_date = null)
        {
            try
            {
                return Ok(await _projectExpenseService.UpdateProjectExpense(id, projectId, expense_type, expense_amount, expense_date));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
