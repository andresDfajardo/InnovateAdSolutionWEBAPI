using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class EmployeeWorkload
    {
        public int id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project project { get; set; }
        [Required]
        public int hours_worked { get; set; }
        public bool is_active { get; set; }
        [Required]
        public DateOnly date { get; set; }
    }
}
