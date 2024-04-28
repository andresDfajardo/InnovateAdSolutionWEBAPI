using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace InnovateAd.Repositories
{
    public interface ITaskRepository
    {
        Task<Entities.Task> CreateTask(int projectId, int employeeId, string description, string start_date, string end_date, string status);
        Task<List<Entities.Task>> GetAll();
        Task<Entities.Task> UpdateTask(Entities.Task task);
        Task<Entities.Task> GetTask(int id);
        Task<Entities.Task> DeleteTask(Entities.Task task);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Entities.Task> CreateTask(int projectId, int employeeId, string description, string start_date, string end_date, string status)
        {
            Entities.Task newTask = new Entities.Task
            {
                ProjectId = projectId,
                EmployeeId = employeeId,
                description = description,
                start_date = start_date,
                end_date = end_date,
                status = status,
                is_active = true
            };
            await _db.Tasks.AddAsync(newTask);
            _db.SaveChanges();
            return newTask;
        }

        public async Task<Entities.Task> DeleteTask(Entities.Task task)
        {
            task.is_active = false;
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<List<Entities.Task>> GetAll()
        {
            return await _db.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> GetTask(int id)
        {
            return await _db.Tasks.FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task<Entities.Task> UpdateTask(Entities.Task task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
            return task;
        }
    }
}
