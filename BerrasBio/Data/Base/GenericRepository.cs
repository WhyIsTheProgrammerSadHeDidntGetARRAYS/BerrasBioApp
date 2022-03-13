using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Base
{
    //implementation of generictype CRUD operations
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            //set is a dbset, and we use 'T' since we dont know what entity we will be adding to
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var actors = await _context.Set<T>().ToListAsync();
            return actors;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var actor = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
