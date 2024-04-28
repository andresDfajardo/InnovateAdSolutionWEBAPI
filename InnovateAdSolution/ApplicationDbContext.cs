using InnovateAd.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnovateAd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<ProjectExpense> ProjectExpenses { get; set; }
        public DbSet<EmployeeWorkload> EmployeeWorkloads { get; set; }
        public DbSet<ProjectRevenue> ProjectRevenues { get; set; }
    }
}
