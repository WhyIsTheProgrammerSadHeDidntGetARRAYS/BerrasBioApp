using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Movie 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //public string ImageURL { get; set; } // ska ha senare
        public MovieCategory Genre { get; set; } 

        //Relationships
        public List<Movie_Actor> MoviesActors { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema? Cinema { get; set; }
    }
}
