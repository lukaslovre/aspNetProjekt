using Botanio_MVC.Data;
using Botanio_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Botanio_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {


            try
            {
                // Get all plants from the database
                var plants = await _context.Plants
                    .Include(p => p.Species)
                    .Include(p => p.Habitat)
                    .Include(p => p.CareInstructions)
                    .ToListAsync();


                // Return view with plants
                return View(plants);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // Route for specific plant
        // GET: /:id
        [HttpGet("{id}")]
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

            // Return view with plant
            return View(plant);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
