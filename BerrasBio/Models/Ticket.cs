using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        // Relationships
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
