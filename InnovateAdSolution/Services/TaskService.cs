
using InnovateAd.Entities;
using InnovateAd.Repositories;

namespace InnovateAd.Services
{
    public interface ITaskService
    {
        Task<Entities.Task> CreateTask(int projectId, int employeeId, string description, DateOnly start_date, DateOnly end_date, string status);
        Task<List<Entities.Task>> GetAll();
        Task<Entities.Task> UpdateTask(int id, int? projectId, int? employeeId, string? description, DateOnly? start_date, DateOnly? end_date, string? status);
        Task<Entities.Task> GetTask(int id);
        Task<Entities.Task> DeleteTask(int id);
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Entities.Task> CreateTask(int projectId, int employeeId, string description, DateOnly start_date, DateOnly end_date, string status)
        {
            return await _taskRepository.CreateTask(projectId, employeeId, description, start_date, end_date, status);
        }

        public async Task<Entities.Task> DeleteTask(int id)
        {
            Entities.Task desactiveTask = await _taskRepository.GetTask(id);

            if (desactiveTask != null)
            {
                desactiveTask.is_active = false;
                return await _taskRepository.DeleteTask(desactiveTask);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Entities.Task>> GetAll()
        {
            return await _taskRepository.GetAll();
        }

        public async Task<Entities.Task> GetTask(int id)
        {
            return await _taskRepository.GetTask(id);
        }

        public async Task<Entities.Task> UpdateTask(int id, int? projectId, int? employeeId, string description, DateOnly? start_date, DateOnly? end_date, string status)
        {
            Entities.Task newtask = await _taskRepository.GetTask(id);

            if (newtask != null)
            {
                if (projectId != null)
                {
                    newtask.ProjectId = (int)projectId;
                }
                else if (employeeId != null)
                {
                    newtask.EmployeeId = (int)employeeId;
                }
                else if (description != null)
                {
                    newtask.description = description;
                }
                else if (start_date != null)
                {
                    newtask.start_date = (DateOnly)start_date;
                }
                else if (end_date != null)
                {
                    newtask.end_date = (DateOnly)end_date;
                }
                else if (status != null)
                {
                    newtask.status = status;
                }
                return await _taskRepository.UpdateTask(newtask);

            }
            else
                return null;
        }
    }
}
