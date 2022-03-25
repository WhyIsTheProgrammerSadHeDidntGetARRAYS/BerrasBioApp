using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Interfaces
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> GetAllCinemas();
        //Task<IEnumerable<Cinema>> GetAllAsync(params Expression<Func<T, object>>[] include);
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema entity);
        Task<Cinema> UpdateAsync(int id, Cinema entity);
        Task Delete(int id);
    }
}
