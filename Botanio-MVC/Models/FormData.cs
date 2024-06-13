namespace Botanio_MVC.Models
{
    public class FormData
    {
        // Form data should contain one Plant object, and a list of all Species, Habitats, and CareInstructions
        public Plant Plant { get; set; }
        public List<Species> AllSpecies { get; set; }
        public List<Habitat> AllHabitats { get; set; }
        public List<CareInstructions> AllCareInstructions { get; set; }

    }
}
