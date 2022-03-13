using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Biography")]
        public string Bio { get; set; } = string.Empty;

        //Relationships
        public List<Movie_Actor>? MoviesActors { get; set; }
    }
}
