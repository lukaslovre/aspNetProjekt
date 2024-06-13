using Botanio_MVC.Data;
using Botanio_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Botanio_MVC.Controllers
{
    [Route("/form/")]
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /
        // Return JSON of all plants
        [HttpGet]
        public IActionResult Index()
        {
            var plants = _context.Plants
                .Include(p => p.Species)
                .Include(p => p.Habitat)
                .Include(p => p.CareInstructions)
                .ToList();


            return Json(plants);
        }



        /*
         *      PLANT ROUTES
         */


        // Render the plant form
        // GET: /plant/:id
        [HttpGet("plant/{id}")]
        public async Task<IActionResult> Plant(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Get plant from the database
            var plant = await _context.Plants
                .Include(p => p.Species)
                .Include(p => p.Habitat)
                .Include(p => p.CareInstructions)
                .FirstOrDefaultAsync(p => p.PlantId == id);

            if (plant == null)
            {
                return View("PlantForm", FormData.Empty(_context));
            }
            else
            {
                FormData formData = FormData.Empty(_context);
                formData.Plant = plant;

                return View("PlantForm", formData);
            }

        }

        // Add new plant to the database
        // POST: /plant
        [HttpPost("plant")]
        public async Task<IActionResult> AddPlant([FromForm] Plant plant)
        {
            // Check if the plant with the plant.plantId already exists
            var existingPlant = await _context.Plants.FindAsync(plant.PlantId);

            // If the plant does not exist, create a new plant
            if (existingPlant == null)
            {
                Plant newPlant = new Plant
                {
                    Name = plant.Name,
                    ScientificName = plant.ScientificName,
                    Description = plant.Description,
                    ImageUrl = plant.ImageUrl,
                    SpeciesId = plant.SpeciesId,
                    HabitatId = plant.HabitatId,
                    CareInstructionsId = plant.CareInstructionsId
                };

                _context.Plants.Add(newPlant);
                _context.SaveChanges();

            } else
            {
                // If the plant exists, update the existing plant
                existingPlant.Name = plant.Name;
                existingPlant.ScientificName = plant.ScientificName;
                existingPlant.Description = plant.Description;
                existingPlant.ImageUrl = plant.ImageUrl;
                existingPlant.SpeciesId = plant.SpeciesId;
                existingPlant.HabitatId = plant.HabitatId;
                existingPlant.CareInstructionsId = plant.CareInstructionsId;

                _context.Plants.Update(existingPlant);
                _context.SaveChanges();
            }

            return Redirect("/");
        }





        /*
         *      HABITAT ROUTES
         */

        // Render the habitat form
        // GET: /habitat/:id
        [HttpGet("habitat/{id}")]
        public async Task<IActionResult> Habitat(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Get habitat from the database
            var habitat = await _context.Habitats.FindAsync(id);

            if (habitat == null)
            {
                return View("HabitatForm", new Habitat());
            }

            // Return view with habitat
            return View("HabitatForm", habitat);
        }

        // Add or update habitat
        // POST: /habitat
        [HttpPost("habitat")]
        public async Task<IActionResult> AddHabitat([FromForm] Habitat habitat)
        {
            // Check if the habitat with the habitat.habitatId already exists
            var existingHabitat = await _context.Habitats.FindAsync(habitat.HabitatId);

            // If the habitat does not exist, create a new habitat
            if (existingHabitat == null)
            {
                Habitat newHabitat = new Habitat
                {
                    Name = habitat.Name,
                    Climate = habitat.Climate,
                    Location = habitat.Location,
                    SoilType = habitat.SoilType
                };

                _context.Habitats.Add(newHabitat);
                _context.SaveChanges();

            } else
            {
                // If the habitat exists, update the existing habitat
                existingHabitat.Name = habitat.Name;
                existingHabitat.Climate = habitat.Climate;
                existingHabitat.Location = habitat.Location;
                existingHabitat.SoilType = habitat.SoilType;

                _context.Habitats.Update(existingHabitat);
                _context.SaveChanges();
            }

            return Redirect("/");
        }






        /*
         *     CARE INSTRUCTIONS ROUTES
         */

        // Render the care instructions form
        // GET: /care-instructions/:id
        [HttpGet("care-instructions/{id}")]
        public async Task<IActionResult> CareInstructions(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Get care instructions from the database
            var careInstructions = await _context.CareInstructions.FindAsync(id);

            if (careInstructions == null)
            {
                return View("CareInstructionsForm", new CareInstructions());
            }

            // Return view with care instructions
            return View("CareInstructionsForm", careInstructions);
        }

        // Add or update care instructions
        // POST: /care-instructions
        [HttpPost("care-instructions")]
        public async Task<IActionResult> AddCareInstructions([FromForm] CareInstructions careInstructions)
        {
            // Check if the care instructions with the careInstructions.careInstructionsId already exists
            var existingCareInstructions = await _context.CareInstructions.FindAsync(careInstructions.CareInstructionsId);

            // If the care instructions do not exist, create a new care instructions
            if (existingCareInstructions == null)
            {
                CareInstructions newCareInstructions = new CareInstructions
                {
                    Name = careInstructions.Name,
                    WateringInstructions = careInstructions.WateringInstructions,
                    SunlightInstructions = careInstructions.SunlightInstructions,
                    TemperatureRangeLow = careInstructions.TemperatureRangeLow,
                    TemperatureRangeHigh = careInstructions.TemperatureRangeHigh,
                    PruningInstructions = careInstructions.PruningInstructions
                };

                _context.CareInstructions.Add(newCareInstructions);
                _context.SaveChanges();

            } else
            {
                // If the care instructions exist, update the existing care instructions
                existingCareInstructions.Name = careInstructions.Name;
                existingCareInstructions.WateringInstructions = careInstructions.WateringInstructions;
                existingCareInstructions.SunlightInstructions = careInstructions.SunlightInstructions;
                existingCareInstructions.TemperatureRangeLow = careInstructions.TemperatureRangeLow;
                existingCareInstructions.TemperatureRangeHigh = careInstructions.TemperatureRangeHigh;
                existingCareInstructions.PruningInstructions = careInstructions.PruningInstructions;

                _context.CareInstructions.Update(existingCareInstructions);
                _context.SaveChanges();
            }

            return Redirect("/");
        }



    }
}
