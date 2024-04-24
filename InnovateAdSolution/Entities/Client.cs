using System.ComponentModel.DataAnnotations;

namespace InnovateAd.Entities
{
    public class Client
    {

        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [StringLength(50)]
        public string last_name { get; set; }
        [StringLength(50)]
        [Required]
        public string doc_type { get; set; }
        [StringLength(50)]
        [Required]
        public string document { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [Required]
        public bool is_active { get; set; }
        public string client_number { get; set; }

    }
}
