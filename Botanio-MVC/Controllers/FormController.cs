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
            // Get the first Plant from db
            var plant = _context.Plants.FirstOrDefault();

            var allSpecies = _context.Species.ToList();
            var allHabitats = _context.Habitats.ToList();
            var allCareInstructions = _context.CareInstructions.ToList();

            // Create a FormData object to hold the Plant and lists of Species, Habitats, and CareInstructions
            var formData = new FormData
            {
                Plant = plant,
                AllSpecies = allSpecies,
                AllHabitats = allHabitats,
                AllCareInstructions = allCareInstructions
            };


            return View("Index", formData);
        }

        // Route for specific plant
        // GET: /:id
        [HttpGet("plant/{id}")]
        public async Task<IActionResult> Plant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get plant from the database
            var plant = await _context.Plants
                .Include(p => p.Species)
                .Include(p => p.Habitat)
                .Include(p => p.CareInstructions)
                .FirstOrDefaultAsync(p => p.PlantId == id);

            if (plant == null)
            {
                return NotFound();
            }

            // TODO: Staviti kasnije ovo u metodu, pošto se ponavlja
            var allSpecies = _context.Species.ToList();
            var allHabitats = _context.Habitats.ToList();
            var allCareInstructions = _context.CareInstructions.ToList();

            // Create a FormData object to hold the Plant and lists of Species, Habitats, and CareInstructions
            var formData = new FormData
            {
                Plant = plant,
                AllSpecies = allSpecies,
                AllHabitats = allHabitats,
                AllCareInstructions = allCareInstructions
            };


            // Return view with plant
            return View("Index", formData);
        }

        // Add new plant to the database
        // POST: /plant
        [HttpPost("plant")]
        public async Task<IActionResult> AddPlant([FromForm] Plant plant)
        {
            // For testing, just return the plant object that was passed in
            return Json(plant);


            //if (ModelState.IsValid)
            //{
            //    _context.Add(plant);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(plant);
        }


        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
