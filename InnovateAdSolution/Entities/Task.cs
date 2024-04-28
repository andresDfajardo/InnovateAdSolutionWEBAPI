using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class Task
    {
        public int id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project project { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
        [StringLength(250)]
        [Required]
        public string description { get; set; }
        [Required]
        public string start_date { get; set; }
        public string end_date { get; set; }
        [StringLength(50)]
        [Required]
        public string status { get; set; }
        public bool is_active { get; set; }
    }
}
