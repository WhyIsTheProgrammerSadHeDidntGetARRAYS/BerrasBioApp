using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Booking : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ticket amount")]
        public int AmountOfTickets { get; set; }

        // Relationships
        public Session Session { get; set; } 
        public int SessionId { get; set; }
        //TODO ta bort Movie referens i booking modellen, för bokning pekar redan på session och i session står det vilken film som visas
        public Movie Movie { get; set; } 
        public int MovieId { get; set; }


        //TODO: Lägga till så man kan se pris i bokningsviewen

    }
}
