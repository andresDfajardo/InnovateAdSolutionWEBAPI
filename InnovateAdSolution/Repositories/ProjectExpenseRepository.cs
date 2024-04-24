using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InnovateAd.Repositories
{
    public interface IProjectExpenseRepository
    {
        Task<ProjectExpense> CreateProjectExpense(int projectId, string expense_type, int expense_amount, DateOnly expense_date);
        Task<List<ProjectExpense>> GetAll();
        Task<ProjectExpense> UpdateProjectExpense(ProjectExpense projectExpense);
        Task<ProjectExpense> GetProjectExpense(int id);
        Task<ProjectExpense> DeleteProjectExpense(ProjectExpense projectExpense);
    }
    public class ProjectExpenseRepository : IProjectExpenseRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectExpenseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ProjectExpense> CreateProjectExpense(int projectId, string expense_type, int expense_amount, DateOnly expense_date)
        {
            ProjectExpense newProjectExpense = new ProjectExpense
            {
                ProjectId = projectId,
                expense_type = expense_type,
                expense_amount = expense_amount,
                expense_date = expense_date,
                is_active = true
            };
            await _db.ProjectExpenses.AddAsync(newProjectExpense);
            _db.SaveChanges();
            return newProjectExpense;
        }

        public async Task<ProjectExpense> DeleteProjectExpense(ProjectExpense projectExpense)
        {
            _db.ProjectExpenses.Update(projectExpense);
            await _db.SaveChangesAsync();
            return projectExpense;
        }
        public async Task<List<ProjectExpense>> GetAll()
        {
            return await _db.ProjectExpenses.ToListAsync();
        }

        public async Task<ProjectExpense> GetProjectExpense(int id)
        {
            return await _db.ProjectExpenses.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<ProjectExpense> UpdateProjectExpense(ProjectExpense projectExpense)
        {
            _db.ProjectExpenses.Update(projectExpense);
            await _db.SaveChangesAsync();
            return projectExpense;
        }
    }
}
