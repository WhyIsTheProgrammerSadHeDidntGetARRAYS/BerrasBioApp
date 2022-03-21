using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }

        //Relationships
        public int SalonId { get; set; }
        public Salon? Salon { get; set; }
        
    }
}
