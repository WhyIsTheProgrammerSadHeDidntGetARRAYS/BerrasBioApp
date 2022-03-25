using BerrasBio.Data.Interfaces;
using BerrasBio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerrasBio.Controllers
{
    public class CinemasController : Controller
    {

        private readonly ICinemaRepository _repository;
        
        public CinemasController(ICinemaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _repository.GetAllCinemas());
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
            _repository.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Actors/details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _repository.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _repository.GetByIdAsync(id);
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
            await _repository.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
