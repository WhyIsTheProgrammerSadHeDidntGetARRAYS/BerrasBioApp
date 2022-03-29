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
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
       
    }
}
