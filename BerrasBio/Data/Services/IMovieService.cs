using BerrasBio.Data.Base;
using BerrasBio.Data.ViewModels;
using BerrasBio.Models;

namespace BerrasBio.Data.Services
{
    public interface IMovieService : IGenericRepository<Movie>
    {
        Task AddNewMovie(MovieViewModel movie);
        Task<NewMovieDropdownVM> GetNewMovieDropdownVM();
        //to get include i use a GetAll method specific to the movies
        Task<IEnumerable<Movie>> GetAllMovies();

        Task<Movie> GetMovieById(int id);

    }
}
