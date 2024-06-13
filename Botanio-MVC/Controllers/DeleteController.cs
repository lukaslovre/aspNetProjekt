using Botanio_MVC.Data;
using Botanio_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Botanio_MVC.Controllers
{
    [Route("/delete")]
    public class DeleteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeleteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // DELETE: /delete/plant/:id
        [HttpDelete("plant/{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound("Plant not found.");
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
            return Ok("Plant deleted successfully.");
        }

        // DELETE: /delete/habitat/:id
        [HttpDelete("habitat/{id}")]
        public async Task<IActionResult> DeleteHabitat(int id)
        {
            var habitat = await _context.Habitats.FindAsync(id);
            if (habitat == null)
            {
                return NotFound("Habitat not found.");
            }

            _context.Habitats.Remove(habitat);
            await _context.SaveChangesAsync();
            return Ok("Habitat deleted successfully.");
        }

        // DELETE: /delete/care-instructions/:id
        [HttpDelete("care-instructions/{id}")]
        public async Task<IActionResult> DeleteCareInstructions(int id)
        {
            var careInstructions = await _context.CareInstructions.FindAsync(id);
            if (careInstructions == null)
            {
                return NotFound("Care Instructions not found.");
            }

            _context.CareInstructions.Remove(careInstructions);
            await _context.SaveChangesAsync();
            return Ok("Care Instructions deleted successfully.");
        }
    }
}
