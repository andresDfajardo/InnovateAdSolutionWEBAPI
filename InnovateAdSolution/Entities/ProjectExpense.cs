using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class ProjectExpense
    {
        public int id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project project { get; set; }
        [StringLength(50)]
        [Required]
        public string expense_type { get; set; }
        [Required]
        public int expense_amount { get; set; }
        [Required]
        public string expense_date { get; set; }
        public bool is_active { get; set; }


    }
}
