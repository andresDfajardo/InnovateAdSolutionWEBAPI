using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace InnovateAd.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(string name, string position, string department, string hire_date, string email, string employee_number);
        Task<List<Employee>> GetAll();
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> GetEmployee(int id);
        Task<Employee> DeleteEmployee(Employee employee);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Employee> CreateEmployee(string name, string position, string department, string hire_date, string email, string employee_number)
        {
            Employee newEmployee = new Employee
            {
                name = name,
                position = position,
                department = department,
                hire_date = hire_date,
                email = email,
                employee_number = employee_number,
                is_active = true
            };
            await _db.Employees.AddAsync(newEmployee);
            _db.SaveChanges();
            return newEmployee;
        }

        public async Task<Employee> DeleteEmployee(Employee employee)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _db.Employees.FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }
    }

}
