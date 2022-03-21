using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class TicketDetail
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }

    }
}
