using BerrasBio.Models;

namespace BerrasBio.Data.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieById(int id);
        Task AddMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(int id, Movie newMovie);
        void DeleteMovie(int id);
    }
}
