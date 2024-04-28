using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class ProjectRevenue
    {
        public int id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project project { get; set; }
        [Required]
        public int revenue_amount { get; set; }
        [Required]
        public string date_received { get; set; }

        public bool is_active { get; set; }

    }
}
