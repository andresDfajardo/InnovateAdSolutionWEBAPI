using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class Project
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string project_name { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client client { get; set; }
        [Required]
        public DateOnly start_date { get; set; }
        public DateOnly end_date { get; set; }
        [StringLength(50)]
        [Required]
        public int budget { get; set; }
        [StringLength(50)]
        [Required]
        public string status { get; set; }
        public bool is_active { get; set; }
        public List<Task> tasks { get; set; }
        public List<ProjectExpense> projectExpenses { get; set; }
        public List<EmployeeWorkload> employeeWorkloads { get; set; }
        public List<ProjectRevenue> projectRevenues { get; set; }

    }
}
