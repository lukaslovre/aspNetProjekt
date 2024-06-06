using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Botanio_MVC.Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ScientificName { get; set; }

        public string Description { get; set; }

        [Url]
        public string ImageUrl { get; set; }


        // Foreign key properties
        public int SpeciesId { get; set; }
        public int HabitatId { get; set; }
        public int CareInstructionsId { get; set; }


        [ForeignKey("SpeciesId")]
        public Species Species { get; set; }

        [ForeignKey("HabitatId")]
        public Habitat Habitat { get; set; }
        [ForeignKey("CareInstructionsId")]
        public CareInstructions CareInstructions { get; set; }
    }
}
