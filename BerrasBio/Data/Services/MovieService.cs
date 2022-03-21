﻿using BerrasBio.Data.Base;
using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Services
{
    public class MovieService : GenericRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovie(MovieViewModel movieVM)
        {
            var movie = new Movie()
            {
                Name = movieVM.Name,
                Description = movieVM.Description,
                Price = movieVM.Price,
                ImageLink = movieVM.ImageURL,
                Genre = movieVM.Genre,
                CinemaId = movieVM.CinemaId,
            };
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();

            var movieActors = new Movie_Actor()
            {
                ActorId = movieVM.ActorId,
                MovieId = movie.Id
            };
            await _context.Movies_Actors.AddAsync(movieActors);
            await _context.SaveChangesAsync();


        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await _context.Movies.Include(c => c.Cinema).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies
                .Include(c => c.Cinema)
                .Include(am => am.MoviesActors)!
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            return movie!;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownVM()
        {
            var dropdown = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(x => x.Name).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(x => x.Name).ToListAsync()
            };
            return dropdown;
        }
    }
}
