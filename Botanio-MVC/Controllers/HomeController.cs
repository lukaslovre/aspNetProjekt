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
            //return View();

            try
            {
                // Get all plants from the database
                var plants = await _context.Plants
                    .Include(p => p.Species)
                    .Include(p => p.Habitat)
                    .Include(p => p.CareInstructions)
                    .ToListAsync();


                // Return JSON for testing
                return Json(plants);
            } catch (Exception ex)
            {
                return Json(ex.Message);
            }
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
