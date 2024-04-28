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
        public string start_date { get; set; }
        public string end_date { get; set; }
        [StringLength(50)]
        [Required]
        public int budget { get; set; }
        [StringLength(50)]
        [Required]
        public string status { get; set; }
        public bool is_active { get; set; }

    }
}
