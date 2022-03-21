using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Base
{
    //implementation of repository interface
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() //behöver en till GetAllAsync
        {
            //här hade jag velat ha möjlighet att inkludera properties
            var entity = await _context.Set<T>().ToListAsync();
            return entity;
        } 
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _context.Set<T>();
            query = include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            //set is a dbset, and we use 'T' since we dont know what entity we will be adding to
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entityToDelete != null) //maybe delete this if-statement, and check for null in controller
            {
                _context.Set<T>().Remove(entityToDelete);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var actor = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return actor!;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var entry = _context.Entry<T>(entity);
            entry.State = EntityState.Modified;
            //_context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

       
    }
}
