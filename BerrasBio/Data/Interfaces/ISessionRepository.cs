using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync();
        Task<Session> GetMovieSessionById(int id);
        Task UpdateSeatsOnBookedSession(int id, int amountOfTickets);
        Task UpdateSeatsOnRemovedBookingSession(int id, int amountOfTickets);
        Task<IEnumerable<Session>> GetBookableSessionsToday();

        Task<IEnumerable<Session>> GetSessionsTodayAsync(int id);
        Task<Session> GetSessionDetails(int? id);
    }
}
