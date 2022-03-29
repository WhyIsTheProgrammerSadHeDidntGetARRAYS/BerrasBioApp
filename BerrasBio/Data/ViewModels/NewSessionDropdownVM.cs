using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.ViewModels
{
    public class NewSessionDropdownVM
    {
        public List<Cinema> Cinemas { get; set; }
        public List<Salon> Salons { get; set; }
        public List<Movie> Movies { get; set; }

        public NewSessionDropdownVM()
        {
            Cinemas = new List<Cinema>();
            Salons = new List<Salon>();
            Movies = new List<Movie>();
        }
    }
}
