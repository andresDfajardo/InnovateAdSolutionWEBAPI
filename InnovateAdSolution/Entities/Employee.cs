using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class Employee
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [StringLength(50)]
        [Required]
        public string position { get; set; }
        [StringLength(50)]
        [Required]
        public string department { get; set; }
        [StringLength (20)]
        [Required]
        public string hire_date { get; set; }
        [StringLength(50)]
        [Required]
        public string email { get; set; }
        [StringLength(50)]
        [Required]
        public string employee_number { get; set; }
        public bool is_active { get; set; }
    }
}
