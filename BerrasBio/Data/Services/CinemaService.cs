using BerrasBio.Data.Base;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Services
{
    public class CinemaService : GenericRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context)
        {
            
        }
    }
}
