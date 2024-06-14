using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Botanio_MVC.Models.Domain
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ScientificName { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }


        // Foreign key properties
        [Required]
        public int SpeciesId { get; set; }

        [Required]
        public int HabitatId { get; set; }

        [Required]
        public int CareInstructionsId { get; set; }


        [ForeignKey("SpeciesId")]
        public Species? Species { get; set; }

        [ForeignKey("HabitatId")]
        public Habitat? Habitat { get; set; }
        [ForeignKey("CareInstructionsId")]
        public CareInstructions? CareInstructions { get; set; }
    }
}
