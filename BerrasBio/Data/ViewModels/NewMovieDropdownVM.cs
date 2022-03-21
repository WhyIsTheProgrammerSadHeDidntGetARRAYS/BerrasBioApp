using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.ViewModels
{
    public class NewMovieDropdownVM
    {
        public List<Actor> Actors { get; set; }
        public List<Cinema> Cinemas { get; set; }

        public NewMovieDropdownVM()
        {
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>();
        }
    }
}
