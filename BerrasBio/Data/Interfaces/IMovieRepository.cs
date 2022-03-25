using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Repository
{
    public interface IMovieRepository
    {
        Task AddNewMovie(NewMovieViewModel movie);
        Task<NewMovieDropdownVM> GetNewMovieDropdownVM();
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
    }
}
