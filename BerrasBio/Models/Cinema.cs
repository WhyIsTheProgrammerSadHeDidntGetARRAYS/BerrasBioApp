using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Cinema 
    {
        [Key] //I think this key annotation overrides the Id property from IEntitybase? Also its not needed either way
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
        public List<Salon>? Salon { get; set; }
    }
}
