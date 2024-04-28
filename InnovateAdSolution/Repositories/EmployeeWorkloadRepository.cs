using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;

namespace InnovateAd.Repositories
{
    public interface IEmployeeWorkloadRepository
    {
        Task<EmployeeWorkload> CreateEmployeeWorkload(int employeeId, int projectId, int hours_worked, string date);
        Task<List<EmployeeWorkload>> GetAll();
        Task<EmployeeWorkload> UpdateEmployeeWorkload(EmployeeWorkload employeeWorkload);
        Task<EmployeeWorkload> GetEmployeeWorkload(int id);
        Task<EmployeeWorkload> DeleteEmployeeWorkload(EmployeeWorkload employeeWorkload);

    }
    public class EmployeeWorkloadRepository : IEmployeeWorkloadRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeWorkloadRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<EmployeeWorkload> CreateEmployeeWorkload(int employeeId, int projectId, int hours_worked, string date)
        {
            EmployeeWorkload newEmployeeWorkload = new EmployeeWorkload
            {
                EmployeeId = employeeId,
                ProjectId = projectId,
                hours_worked = hours_worked,
                date = date,
                is_active = true
            };
            await _db.EmployeeWorkloads.AddAsync(newEmployeeWorkload);
            _db.SaveChanges();
            return newEmployeeWorkload;
        }

        public async Task<EmployeeWorkload> DeleteEmployeeWorkload(EmployeeWorkload employeeWorkload)
        {
            employeeWorkload.is_active = false;
            _db.EmployeeWorkloads.Update(employeeWorkload);
            await _db.SaveChangesAsync();
            return employeeWorkload;
        }
        public async Task<List<EmployeeWorkload>> GetAll()
        {
            return await _db.EmployeeWorkloads.ToListAsync();
        }

        public async Task<EmployeeWorkload> GetEmployeeWorkload(int id)
        {
            return await _db.EmployeeWorkloads.FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task<EmployeeWorkload> UpdateEmployeeWorkload(EmployeeWorkload employeeWorkload)
        {
            _db.EmployeeWorkloads.Update(employeeWorkload);
            await _db.SaveChangesAsync();
            return employeeWorkload;
        }
    }
}
