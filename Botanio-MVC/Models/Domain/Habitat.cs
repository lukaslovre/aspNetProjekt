using System.ComponentModel.DataAnnotations;

namespace Botanio_MVC.Models.Domain
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Climate { get; set; }

        public string Location { get; set; }

        public string SoilType { get; set; }
    }
}
