using System.ComponentModel.DataAnnotations;

namespace Botanio_MVC.Models
{
    public class CareInstructions
    {
        [Key]
        public int CareInstructionsId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string WateringInstructions { get; set; }

        [Required]
        public string SunlightInstructions { get; set; }

        [Required]
        public int TemperatureRangeLow { get; set; }

        [Required]
        public int TemperatureRangeHigh { get; set; }

        public string PruningInstructions { get; set; }
    }
}
