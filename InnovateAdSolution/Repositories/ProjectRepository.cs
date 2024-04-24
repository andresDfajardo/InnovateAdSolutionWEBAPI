using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;

namespace InnovateAd.Repositories
{

    public interface IProjectRepository
    {
        Task<Project> CreateProject(string project_name, int clientId, DateOnly start_date, DateOnly end_date, int budget, string status);
        Task<List<Project>> GetAll();
        Task<Project> UpdateProject(Project project);
        Task<Project> GetProject(int id);
        Task<Project> DeleteProject(Project project);
    }
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Project> CreateProject(string project_name, int clientId, DateOnly start_date, DateOnly end_date, int budget, string status)
        {
            Project newProject = new Project
            {
                project_name = project_name,
                ClientId = clientId,
                start_date = start_date,
                end_date = end_date,
                budget = budget,
                status = status,
                is_active = true
            };
            await _db.Projects.AddAsync(newProject);
            _db.SaveChanges();
            return newProject;
        }

        public async Task<Project> DeleteProject(Project project)
        {
            _db.Projects.Update(project);
            await _db.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _db.Projects.ToListAsync();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _db.Projects.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            _db.Projects.Update(project);
            await _db.SaveChangesAsync();
            return project;
        }
    }
}
