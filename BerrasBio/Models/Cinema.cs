using BerrasBio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationship
        public List<Movie>? Movies { get; set; }
    }
}
