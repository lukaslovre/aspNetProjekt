using System.ComponentModel.DataAnnotations;

namespace Botanio_MVC.Models.Domain
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }

        [Required]
        public string ScientificName { get; set; }

        [Required]
        public string CommonName { get; set; }

        [Required]
        public string Origin { get; set; }

        public string? Description { get; set; }
    }
}
