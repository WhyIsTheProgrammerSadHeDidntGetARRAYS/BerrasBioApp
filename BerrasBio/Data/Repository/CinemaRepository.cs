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
    public class CinemaRepository : ICinemaRepository
    {
        private readonly AppDbContext _context;

        public CinemaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cinema>> GetAllCinemas() => await _context.Cinemas.ToListAsync();
        
        //public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    query = include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //    return await query.ToListAsync();
        //}
        public async Task AddAsync(Cinema cinema)
        {
            //set is a dbset, and we use 'T' since we dont know what entity we will be adding to
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cinemaToDelete = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Cinemas.Remove(cinemaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var actor = await _context.Cinemas.Include(s => s.Salon).FirstOrDefaultAsync(x => x.Id == id);
            return actor!;
        }

        public async Task<Cinema> UpdateAsync(int id, Cinema cinema)
        {
            var entry = _context.Entry(cinema);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cinema;
        }
    }
}
