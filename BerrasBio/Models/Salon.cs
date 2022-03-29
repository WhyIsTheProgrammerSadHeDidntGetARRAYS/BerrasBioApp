using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Salon 
    {
        [Key]
        public int Id { get; set; }
        public string? SalonName { get; set; } 
        public int TotalSeats { get; set; } 

        //Relationships
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
        public List<Session>? Sessions { get; set; }
    }
}
