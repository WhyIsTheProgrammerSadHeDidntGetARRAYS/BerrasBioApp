using BerrasBio.Data.Base;
using BerrasBio.Data.Repository;
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
        private readonly IMovieRepository _repository;

        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllMovies());
            
        }
        /// <summary>
        /// /Movies/Create
        /// </summary>
        /// <returns>View of input forms</returns>
        public async Task<IActionResult> Create()
        {
            var movieData = await _repository.GetNewMovieDropdownVM(); //should maybe be in a service folder
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
        public async Task<IActionResult> Create(NewMovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var movieData = await _repository.GetNewMovieDropdownVM();
                ViewBag.Cinemas = new SelectList(movieData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieData.Actors, "Id", "Name");
                return View(movie);
            }
            await _repository.AddNewMovie(movie);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// /Movies/Details/Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View of listed item</returns>
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _repository.GetMovieById(id);
            return View(movieDetails);
        }
    }
}
