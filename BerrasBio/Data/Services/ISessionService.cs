using BerrasBio.Data.Base;
using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Services
{
    public interface ISessionService : IGenericRepository<Session>
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync();
        Task<Session> GetMovieSessionById(int id);
    }
}
