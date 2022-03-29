using BerrasBio.Data.Interfaces;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Repository
{
    public class SalonRepository : ISalonRepository
    {
        private readonly AppDbContext _context;

        public SalonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Salon> GetSalonById(int? id)
        {
            var session = await _context.Salons.Where(s => s.Id == id).FirstOrDefaultAsync();
            return session;
        }
    }
}
