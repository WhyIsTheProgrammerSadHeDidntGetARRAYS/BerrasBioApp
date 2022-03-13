using BerrasBio.Data.Services;
using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BerrasBio.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllMoviesAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            
            await _service.AddMovieAsync(movie);
            return RedirectToAction("Index");
        }
    }
}
