using System.ComponentModel.DataAnnotations;

namespace Botanio_MVC.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }

        [Required]
        public string ScientificName { get; set; }

        [Required]
        public string CommonName { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }
    }
}
