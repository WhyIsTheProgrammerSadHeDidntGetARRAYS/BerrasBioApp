using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddMovieAsync(Movie actor)
        {
            await _context.Movies.AddAsync(actor);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }

        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovieAsync(int id, Movie newMovie)
        {
            throw new NotImplementedException();
        }
    }
}
