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
        public async Task<ActionResult<ProjectExpense>> CreateProjectExpense(int projectId, string expense_type, int expense_amount, DateOnly expense_date)
        {
            var newProjectExpense = await _projectExpenseService.CreateProjectExpense(projectId, expense_type, expense_amount, expense_date);
            return CreatedAtAction(nameof(GetProjectExpense), new { newProjectExpense.id }, newProjectExpense);
        }
    }
}
