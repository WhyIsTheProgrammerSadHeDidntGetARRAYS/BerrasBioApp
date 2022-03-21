using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.ViewModels
{
    public class NewSessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int AvailableSeats { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
        public Salon Salon { get; set; }
       
    }
}
