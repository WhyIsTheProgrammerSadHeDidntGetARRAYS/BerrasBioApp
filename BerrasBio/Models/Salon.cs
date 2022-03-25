using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Salon : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        //eller bara ha en int ist för Seat som en klass?
        //public ICollection<Seat> Seats { get; set; }
        public string? SalonName { get; set; } 

        // Eller ha en klass för Seat? Varje plats i salongen måste ha ett unikt "id"
        // dock är det fattig namngivning, för totalseats kommer inte ändras. Isf behöver jag en till för available seats
        public int TotalSeats { get; set; } 

        //Relationships
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
        public List<Session>? Sessions { get; set; }
    }
}
