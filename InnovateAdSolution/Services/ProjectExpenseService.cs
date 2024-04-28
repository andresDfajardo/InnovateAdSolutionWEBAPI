using InnovateAd.Entities;
using InnovateAd.Repositories;

namespace InnovateAd.Services
{
    public interface IProjectExpenseService
    {
        Task<ProjectExpense> CreateProjectExpense(int projectId, string expense_type, int expense_amount, string expense_date);
        Task<List<ProjectExpense>> GetAll();
        Task<ProjectExpense> UpdateProjectExpense(int id, int? projectId=null, string? expense_type=null, int? expense_amount = null, string? expense_date=null);
        Task<ProjectExpense> GetProjectExpense(int id);
        Task<ProjectExpense> DeleteProjectExpense(int id);
    }
    public class ProjectExpenseService : IProjectExpenseService
    {
        private readonly IProjectExpenseRepository _projectExpenseRepository;
        public ProjectExpenseService(IProjectExpenseRepository projectExpenseRepository)
        {
            _projectExpenseRepository = projectExpenseRepository;
        }
        public async Task<ProjectExpense> CreateProjectExpense(int projectId, string expense_type, int expense_amount, string expense_date)
        {
            return await _projectExpenseRepository.CreateProjectExpense(projectId, expense_type, expense_amount, expense_date);
        }

        public async Task<ProjectExpense> DeleteProjectExpense(int id)
        {
            ProjectExpense desactiveProjectExpense = await _projectExpenseRepository.GetProjectExpense(id);

            if (desactiveProjectExpense != null)
            {
                desactiveProjectExpense.is_active = false;
                return await _projectExpenseRepository.DeleteProjectExpense(desactiveProjectExpense);
            }
            else
            {
                throw new Exception("Project Expense not found");
            }
        }

        public async Task<List<ProjectExpense>> GetAll()
        {
            return await _projectExpenseRepository.GetAll();
        }

        public async Task<ProjectExpense> GetProjectExpense(int id)
        {
            return await _projectExpenseRepository.GetProjectExpense(id);
        }

        public async Task<ProjectExpense> UpdateProjectExpense(int id, int? projectId, string expense_type, int? expense_amount, string? expense_date)
        {
            ProjectExpense newprojectexpense = await _projectExpenseRepository.GetProjectExpense(id);

            if (newprojectexpense != null)
            {
                if (projectId != null)
                {
                    newprojectexpense.ProjectId = (int)projectId;
                }
                else if (expense_type != null)
                {
                    newprojectexpense.expense_type = expense_type;
                }
                else if (expense_amount != null)
                {
                    newprojectexpense.expense_amount = (int)expense_amount;
                }
                else if (expense_date != null)
                {
                    newprojectexpense.expense_date = expense_date;
                }
                return await _projectExpenseRepository.UpdateProjectExpense(newprojectexpense);
            }
            else
                return null;
        }
    }
}
