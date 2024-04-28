using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;

namespace InnovateAd.Repositories
{
    public interface IProjectRevenueRepository
    {
        Task<ProjectRevenue> CreateProjectRevenue(int projectId, int revenue_amount, string date_received);
        Task<List<ProjectRevenue>> GetAll();
        Task<ProjectRevenue> UpdateProjectRevenue(ProjectRevenue projectRevenue);
        Task<ProjectRevenue> GetProjectRevenue(int id);
        Task<ProjectRevenue> DeleteProjectRevenue(ProjectRevenue projectRevenue);

    }
    public class ProjectRevenueRepository : IProjectRevenueRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectRevenueRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ProjectRevenue> CreateProjectRevenue(int projectId, int revenue_amount, string date_received)
        {
            ProjectRevenue newProjectRevenue = new ProjectRevenue
            {
                ProjectId = projectId,
                revenue_amount = revenue_amount,
                date_received = date_received,
                is_active = true
            };
            await _db.ProjectRevenues.AddAsync(newProjectRevenue);
            _db.SaveChanges();
            return newProjectRevenue;
        }

        public async Task<ProjectRevenue> DeleteProjectRevenue(ProjectRevenue projectRevenue)
        {
            projectRevenue.is_active = false;
            _db.ProjectRevenues.Update(projectRevenue);
            await _db.SaveChangesAsync();
            return projectRevenue;
        }

        public async Task<List<ProjectRevenue>> GetAll()
        {
            return await _db.ProjectRevenues.ToListAsync();
        }

        public async Task<ProjectRevenue> GetProjectRevenue(int id)
        {
            return await _db.ProjectRevenues.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<ProjectRevenue> UpdateProjectRevenue(ProjectRevenue projectRevenue)
        {
            _db.ProjectRevenues.Update(projectRevenue);
            await _db.SaveChangesAsync();
            return projectRevenue;
        }
    }
}
