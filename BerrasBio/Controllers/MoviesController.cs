using BerrasBio.Data.Base;
using BerrasBio.Data.Services;
using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
            return View(await _service.GetAllAsync());
            
        }
        /// <summary>
        /// /Movies/Create
        /// </summary>
        /// <returns>View of input forms</returns>
        public async Task<IActionResult> Create()
        {
            var movieData = await _service.GetNewMovieDropdownVM();
            ViewBag.Cinemas = new SelectList(movieData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieData.Actors, "Id", "Name");
            return View();
        }
        /// <summary>
        /// /Movies/Create
        /// </summary>
        /// <param name="movie"></param>
        /// Post request
        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var movieData = await _service.GetNewMovieDropdownVM();
                ViewBag.Cinemas = new SelectList(movieData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieData.Actors, "Id", "Name");
                return View(movie);
            }
            await _service.AddNewMovie(movie);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// /Movies/Details/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View of listed item</returns>
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieById(id);
            return View(movieDetails);
        }
    }
}
