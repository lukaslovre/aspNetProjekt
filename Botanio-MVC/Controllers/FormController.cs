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
        // just return the view
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

        // Route for specific plant
        // GET: /:id
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
                return View("Index", FormData.Empty(_context));
            }

            FormData formData = FormData.Empty(_context);
            formData.Plant = plant;

            // Return view with plant
            return View("Index", formData);
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


            return RedirectToAction(nameof(Index));
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

            return RedirectToAction(nameof(Index));
        }



    }
}
