using Botanio_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Botanio_MVC.Models
{
    public class FormData
    {
        // Form data should contain one Plant object, and a list of all Species, Habitats, and CareInstructions
        public Plant Plant { get; set; }
        public List<Species> AllSpecies { get; set; }
        public List<Habitat> AllHabitats { get; set; }
        public List<CareInstructions> AllCareInstructions { get; set; }


        // Method that returns an empty FormData object
        public static FormData Empty(ApplicationDbContext context)
        {
            return new FormData
            {
                Plant = new Plant(),
                AllSpecies = GetAllSpecies(context),
                AllHabitats = GetAllHabitats(context),
                AllCareInstructions = GetAllCareInstructions(context)
            };
        }

        // Generate 3 methods, one for each of the lists in FormData, it takes an context as argument, and gets all the items from that table
        public static List<Species> GetAllSpecies(ApplicationDbContext context)
        {
            return context.Species.ToList();
        }
        public static List<Habitat> GetAllHabitats(ApplicationDbContext context)
        {
            return context.Habitats.ToList();
        }
        public static List<CareInstructions> GetAllCareInstructions(ApplicationDbContext context)
        {
            return context.CareInstructions.ToList();
        }
    }
}
