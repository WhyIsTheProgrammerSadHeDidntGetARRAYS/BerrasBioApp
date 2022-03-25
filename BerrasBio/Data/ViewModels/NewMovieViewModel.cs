using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.ViewModels
{
    public class NewMovieViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        public double Price { get; set; }
        [Display(Name = "Movie Image url")]
        public string ImageURL { get; set; } 
        [Display(Name = "Select Genre")]
        public MovieCategory Genre { get; set; }

        [Display(Name = "Select Actor")]
        public int ActorId { get; set; }
        
        [Display(Name = "Select Cinema")]
        public int CinemaId { get; set; }
        
    }
}
