using Botanio_MVC.Data;
using Botanio_MVC.Models.Domain;
using Botanio_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        // GET: /form/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var plants = await _context.Plants
                .Include(p => p.Species)
                .Include(p => p.Habitat)
                .Include(p => p.CareInstructions)
                .ToListAsync();

            return Json(plants);
        }

        // GET: /form/plant/:id
        [HttpGet("plant/{id?}")]
        public async Task<IActionResult> Plant(int? id)
        {
            if (id == null)
                return View("PlantForm", FormData.Empty(_context));

            Plant? plant = await _context.Plants
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

        // POST: /form/plant
        [HttpPost("plant")]
        public async Task<IActionResult> AddPlant([FromForm] Plant plant)
        {
            if (plant == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                // Log exactly what field causing the ModelState to be invalid
                foreach (var key in ModelState.Keys)
                {
                    if (ModelState[key].Errors.Count > 0)
                    {
                        // Print
                        Console.WriteLine($"Field {key} is invalid: {ModelState[key].Errors[0].ErrorMessage}");
                    }
                }




                FormData formData = FormData.Empty(_context);
                formData.Plant = plant;
                return View("PlantForm", formData);
            }

            await AddOrUpdateEntity(_context.Plants, plant, plant.PlantId);
            return Redirect("/");
        }

        // GET: /form/habitat/:id
        [HttpGet("habitat/{id?}")]
        public async Task<IActionResult> Habitat(int? id)
        {
            if (id == null)
                return View("HabitatForm", new Habitat());

            var habitat = await _context.Habitats.FindAsync(id);
            return View("HabitatForm", habitat ?? new Habitat());
        }

        // POST: /form/habitat
        [HttpPost("habitat")]
        public async Task<IActionResult> AddHabitat([FromForm] Habitat habitat)
        {
            if (habitat == null)
                return BadRequest();

            await AddOrUpdateEntity(_context.Habitats, habitat, habitat.HabitatId);
            return Redirect("/");
        }

        // GET: /form/care-instructions/:id
        [HttpGet("care-instructions/{id?}")]
        public async Task<IActionResult> CareInstructions(int? id)
        {
            if (id == null)
                return View("CareInstructionsForm", new CareInstructions());

            var instructions = await _context.CareInstructions.FindAsync(id);
            return View("CareInstructionsForm", instructions ?? new CareInstructions());
        }

        // POST: /form/care-instructions
        [HttpPost("care-instructions")]
        public async Task<IActionResult> AddCareInstructions([FromForm] CareInstructions instructions)
        {
            if (instructions == null)
                return BadRequest();

            await AddOrUpdateEntity(_context.CareInstructions, instructions, instructions.CareInstructionsId);
            return Redirect("/");
        }

        private async Task AddOrUpdateEntity<T>(DbSet<T> dbSet, T entity, int id) where T : class
        {
            var existingEntity = await dbSet.FindAsync(id);

            if (existingEntity == null)
            {
                dbSet.Add(entity);
            }
            else
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
