using BerrasBio.Data.Services;
using BerrasBio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerrasBio.Controllers
{
    public class CinemasController : Controller
    {
        // GET: CinemasController
        private readonly ICinemaService _service;
        public CinemasController(ICinemaService service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Actors/details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
