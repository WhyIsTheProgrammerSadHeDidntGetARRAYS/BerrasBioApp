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
    public class SessionService : GenericRepository<Session>, ISessionService
    {
        private readonly AppDbContext _context;
        public SessionService(AppDbContext context) : base(context) { _context = context; }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            var sessions = await _context.Sessions.Include(c => c.Cinema).Include(m => m.Movie).Include(s => s.Salon).ToListAsync();
            return sessions;
        }

        public Task<Session> GetMovieSessionById(int id)
        {
            var specificSession = _context.Sessions.FirstOrDefaultAsync(x => x.Id == id);
            return specificSession; //null is allowed here, we check for nulls in controller, fuck this squiggly
        }
    }
}
