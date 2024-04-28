using InnovateAd.Entities;
using InnovateAd.Repositories;

namespace InnovateAd.Services
{
    public interface IEmployeeWorkloadService
    {
        Task<EmployeeWorkload> CreateEmployeeWorkload(int employeeId, int projectId, int hours_worked, string date);
        Task<List<EmployeeWorkload>> GetAll();
        Task<EmployeeWorkload> UpdateEmployeeWorkload(int id, int? employeeId=null, int? projectId = null, int? hours_worked = null, string? date=null);
        Task<EmployeeWorkload> GetEmployeeWorkload(int id);
        Task<EmployeeWorkload> DeleteEmployeeWorkload(int id);
    }
    public class EmployeeWorkloadService : IEmployeeWorkloadService
    {
        private readonly IEmployeeWorkloadRepository _employeeWorkloadRepository;
        public EmployeeWorkloadService(IEmployeeWorkloadRepository employeeWorkloadRepository)
        {
            _employeeWorkloadRepository = employeeWorkloadRepository;
        }
        public async Task<EmployeeWorkload> CreateEmployeeWorkload(int employeeId, int projectId, int hours_worked, string date)
        {
            return await _employeeWorkloadRepository.CreateEmployeeWorkload(employeeId, projectId, hours_worked, date);
        }

        public async Task<EmployeeWorkload> DeleteEmployeeWorkload(int id)
        {
            EmployeeWorkload desactiveEmployeeWorkload = await _employeeWorkloadRepository.GetEmployeeWorkload(id);

            if (desactiveEmployeeWorkload != null)
            {
                desactiveEmployeeWorkload.is_active = false;
                return await _employeeWorkloadRepository.DeleteEmployeeWorkload(desactiveEmployeeWorkload);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<EmployeeWorkload>> GetAll()
        {
            return await _employeeWorkloadRepository.GetAll();
        }

        public async Task<EmployeeWorkload> GetEmployeeWorkload(int id)
        {
            return await _employeeWorkloadRepository.GetEmployeeWorkload(id);
        }

        public async Task<EmployeeWorkload> UpdateEmployeeWorkload(int id, int? employeeId, int? projectId, int? hours_worked, string? date)
        {
            EmployeeWorkload newemployeeworkload = await _employeeWorkloadRepository.GetEmployeeWorkload(id);

            if (newemployeeworkload != null)
            {
                if (employeeId != null)
                {
                    newemployeeworkload.EmployeeId = (int)employeeId;
                }
                else if (projectId != null)
                {
                    newemployeeworkload.ProjectId = (int)projectId;
                }
                else if (hours_worked != null)
                {
                    newemployeeworkload.hours_worked = (int)hours_worked;
                }
                else if (date != null)
                {
                    newemployeeworkload.date = date;
                }
                return await _employeeWorkloadRepository.UpdateEmployeeWorkload(newemployeeworkload);

            }
            else
                return null;
        }
    }
}
