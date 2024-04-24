using InnovateAd.Entities;
using InnovateAd.Repositories;

namespace InnovateAd.Services
{
    public interface IProjectRevenueService
    {
        Task<ProjectRevenue> CreateProjectRevenue(int projectId, int revenue_amount, DateOnly date_received);
        Task<List<ProjectRevenue>> GetAll();
        Task<ProjectRevenue> UpdateProjectRevenue(int id, int? projectId, int? revenue_amount, DateOnly? date_received);
        Task<ProjectRevenue> GetProjectRevenue(int id);
        Task<ProjectRevenue> DeleteProjectRevenue(int id);
    }
    public class ProjectRevenueService : IProjectRevenueService
    {
        private readonly IProjectRevenueRepository _projectRevenueRepository;
        public ProjectRevenueService(IProjectRevenueRepository projectRevenueRepository)
        {
            _projectRevenueRepository = projectRevenueRepository;
        }
        public async Task<ProjectRevenue> CreateProjectRevenue(int projectId, int revenue_amount, DateOnly date_received)
        {
            return await _projectRevenueRepository.CreateProjectRevenue(projectId, revenue_amount, date_received);
        }

        public async Task<ProjectRevenue> DeleteProjectRevenue(int id)
        {
            ProjectRevenue desactiveProjectRevenue = await _projectRevenueRepository.GetProjectRevenue(id);

            if (desactiveProjectRevenue != null)
            {
                desactiveProjectRevenue.is_active = false;
                return await _projectRevenueRepository.DeleteProjectRevenue(desactiveProjectRevenue);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProjectRevenue>> GetAll()
        {
            return await _projectRevenueRepository.GetAll();
        }

        public async Task<ProjectRevenue> GetProjectRevenue(int id)
        {
            return await _projectRevenueRepository.GetProjectRevenue(id);
        }

        public async Task<ProjectRevenue> UpdateProjectRevenue(int id, int? projectId, int? revenue_amount, DateOnly? date_received)
        {
            ProjectRevenue newprojectrevenue = await _projectRevenueRepository.GetProjectRevenue(id);

            if (newprojectrevenue != null)
            {
                if (projectId != null)
                {
                    newprojectrevenue.ProjectId = (int)projectId;
                }
                else if (revenue_amount != null)
                {
                    newprojectrevenue.revenue_amount = (int)revenue_amount;
                }
                else if (date_received != null)
                {
                    newprojectrevenue.date_received = (DateOnly)date_received;
                }
                return await _projectRevenueRepository.UpdateProjectRevenue(newprojectrevenue);

            }
            else
                return null;
        }
    }
}
