using InnovateAd.Entities;
using InnovateAd.Repositories;

namespace InnovateAd.Services
{
    public interface IProjectService
    {
        Task<Project> CreateProject(string project_name, int clientId, string start_date, string end_date, int budget, string status);
        Task<List<Project>> GetAll();
        Task<Project> UpdateProject(int id, string? project_name=null, int? clientId=null, string? start_date=null, string? end_date=null, int? budget=null, string? status = null);
        Task<Project> GetProject(int id);
        Task<Project> DeleteProject(int id);
    }
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> CreateProject(string project_name, int clientId, string start_date, string end_date, int budget, string status)
        {
            return await _projectRepository.CreateProject(project_name, clientId, start_date, end_date, budget, status);
        }

        public async Task<Project> DeleteProject(int id)
        {
            Project desactiveProject = await _projectRepository.GetProject(id);

            if (desactiveProject != null)
            {
                desactiveProject.is_active = false;
                return await _projectRepository.DeleteProject(desactiveProject);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _projectRepository.GetProject(id);
        }

        public async Task<Project> UpdateProject(int id, string project_name, int? clientId, string? start_date, string? end_date, int? budget, string status)
        {
            Project newproject = await _projectRepository.GetProject(id);

            if (newproject != null)
            {
                if (project_name != null)
                {
                    newproject.project_name = project_name;
                }
                else if (clientId != null)
                {
                    newproject.ClientId = (int)clientId;
                }
                else if (start_date != null)
                {
                    newproject.start_date = start_date;
                }
                else if (end_date != null)
                {
                    newproject.end_date = end_date;
                }
                else if (budget != null)
                {
                    newproject.budget = (int)budget;
                }
                else if (status != null)
                {
                    newproject.status = status;
                }
                return await _projectRepository.UpdateProject(newproject);
            }
            else
                return null;
        }
    }
}
