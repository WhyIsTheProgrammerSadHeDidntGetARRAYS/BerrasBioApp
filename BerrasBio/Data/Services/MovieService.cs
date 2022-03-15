using BerrasBio.Data.Base;
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
        public MovieService(AppDbContext context) : base(context) { }
       
    }
}
