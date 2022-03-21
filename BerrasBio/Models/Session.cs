using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    //Visning för en specifik film
    public class Session : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int AvailableSeats { get; set; }

        //Relationships

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public int SalonId { get; set; }

        public Salon Salon { get; set; }
        

    }
}
