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
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;
        
        public SessionRepository(AppDbContext context) 
        { 
            _context = context; 
        }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            var sessions = await _context.Sessions
                .Include(c => c.Cinema)
                .Include(m => m.Movie)
                .Include(s => s.Salon)
                .ToListAsync();
            return sessions; //this method could be removed since we only want to show todays active sessions (see GetSessionsToday)
        }

        public Task<Session> GetMovieSessionById(int id)
        {
            var specificSession = _context.Sessions.FirstOrDefaultAsync(s => s.Id == id);
            return specificSession;
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
        public async Task<IEnumerable<Session>> GetSessionsTodayAsync(int id)
        {
            var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var sessionsToday = await _context.Sessions
                .Include(c => c.Cinema)
                .Include(m => m.Movie)
                .Include(s => s.Salon)
                .Where(x => x.StartDate >= todaysDate && x.MovieId == id)
                .ToListAsync();

            return sessionsToday;
        }

        public async Task UpdateSeatsOnBookedSession(int id, int amountOfTickets)
        {
            var activeSession = await _context.Sessions.FirstOrDefaultAsync(x => x.Id == id);
            if (activeSession != null)
            {
                activeSession.AvailableSeats -= amountOfTickets;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateSeatsOnRemovedBookingSession(int id, int amountOfTickets)
        {
            var activeSession = await _context.Sessions.FirstOrDefaultAsync(x => x.Id == id);
            if (activeSession != null)
            {
                activeSession.AvailableSeats += amountOfTickets;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Session> GetSessionDetails(int? id)
        {
            var session = await _context.Sessions
                .Include(s => s.Cinema)
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            return session;
        }
    }
}
