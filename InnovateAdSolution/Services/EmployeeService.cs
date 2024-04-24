using InnovateAd.Entities;
using InnovateAd.Repositories;
using System.Reflection.Metadata;
using System.Xml.Linq;


namespace InnovateAd.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(string name, string position, string department, DateOnly hire_date, string email, string employee_number);
        Task<List<Employee>> GetAll();
        Task<Employee> UpdateEmployee(int id, string? name, string? position, string? department, DateOnly? hire_date, string? email, string? employee_number);
        Task<Employee> GetEmployee(int id);
        Task<Employee> DeleteEmployee(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> CreateEmployee(string name, string position, string department, DateOnly hire_date, string email, string employee_number)
        {
            return await _employeeRepository.CreateEmployee(name, position, department, hire_date, email, employee_number);
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee desactiveEmployee = await _employeeRepository.GetEmployee(id);

            if (desactiveEmployee != null)
            {
                desactiveEmployee.is_active = false;
                return await _employeeRepository.DeleteEmployee(desactiveEmployee);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<Employee> UpdateEmployee(int id, string name, string position, string department, DateOnly? hire_date, string email, string employee_number)
        {
            Employee newemployee = await _employeeRepository.GetEmployee(id);

            if (newemployee != null)
            {
                if (name != null)
                {
                    newemployee.name = name;
                }
                else if (position != null)
                {
                    newemployee.position = position;
                }
                else if (department != null)
                {
                    newemployee.department = department;
                }
                else if (hire_date != null)
                {
                    newemployee.hire_date = (DateOnly)hire_date;
                }
                else if (email != null)
                {
                    newemployee.email = email;
                }
                else if (employee_number != null)
                {
                    newemployee.employee_number = employee_number;
                }
                return await _employeeRepository.UpdateEmployee(newemployee);
            }
            else
                return null;
        }
    }
}
