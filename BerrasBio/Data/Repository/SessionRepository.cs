using BerrasBio.Data.Interfaces;
using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddNewSession(Session newSession)
        {
            await _context.Sessions.AddAsync(newSession);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Session>> GetBookableSessionsToday()
        {
            var sessionsToday = await _context.Sessions
                .Include(c => c.Cinema)
                .Include(m => m.Movie)
                .Include(s => s.Salon)
                .Where(x => x.StartDate >= DateTime.Now)
                .ToListAsync();

            return sessionsToday;
        }
        

        public async Task UpdateSessionseatsOnNewBooking(int id, int amountOfTickets)
        {
            //var activeSession = await _context.Sessions.FirstOrDefaultAsync(x => x.Id == id);
            var test = await GetSessionById(id);
            if (test != null)
            {
                test.AvailableSeats -= amountOfTickets;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateSessionseatsOnRemovedBooking(int id, int amountOfTickets)
        {
            var activeSession = await GetSessionById(id);
            if (activeSession != null)
            {
                activeSession.AvailableSeats += amountOfTickets;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Session> GetSessionById(int? id)
        {
            var session = await _context.Sessions
                .Include(s => s.Cinema)
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            return session;
        }
        public async Task<NewSessionDropdownVM> GetNewSessionDropdown()
        {
            var dropDown = new NewSessionDropdownVM()
            {
                Cinemas = await _context.Cinemas.OrderBy(x => x.Id).ToListAsync(),
                Movies = await _context.Movies.OrderBy(x => x.Id).ToListAsync(),
                Salons = await _context.Salons.OrderBy(x => x.Id).ToListAsync()
            };
            return dropDown;
        }

        public async Task Delete(Session session)
        {
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Session session)
        {
            var entry = _context.Entry(session);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
        //public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        //{
        //    var sessions = await _context.Sessions
        //        .Include(c => c.Cinema)
        //        .Include(m => m.Movie)
        //        .Include(s => s.Salon)
        //        .ToListAsync();
        //    return sessions; //this method could be removed since we only want to show todays active sessions (see GetSessionsToday)
        //}
        
        //public async Task<IEnumerable<Session>> GetSessionsTodayAsync(int id)
        //{
        //    var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        //    var sessionsToday = await _context.Sessions
        //        .Include(c => c.Cinema)
        //        .Include(m => m.Movie)
        //        .Include(s => s.Salon)
        //        .Where(x => x.StartDate >= todaysDate && x.MovieId == id)
        //        .ToListAsync();

        //    return sessionsToday;
        //}
    }
}
