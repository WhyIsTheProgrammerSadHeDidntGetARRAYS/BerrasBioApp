using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.ViewModels
{
    public class NewBookingDropdownVM
    {
        public List<Session> Sessions { get; set; }
        public List<Movie> Movies { get; set; }
        
        public NewBookingDropdownVM()
        {
            Sessions = new List<Session>();
            Movies = new List<Movie>();
        }
    }
}
