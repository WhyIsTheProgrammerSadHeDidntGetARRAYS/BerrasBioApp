using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        //relationships
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        
        public Movie Movie { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }

    }
}
