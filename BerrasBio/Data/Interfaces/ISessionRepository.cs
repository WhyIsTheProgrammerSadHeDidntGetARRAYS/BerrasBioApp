using BerrasBio.Data.ViewModels;
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
        Task AddNewSession(Session newSession);
        Task<NewSessionDropdownVM> GetNewSessionDropdown();
        Task<IEnumerable<Session>> GetAllSessionsAsync(); //använder ej ta bort?
        Task UpdateSeatsOnBookedSession(int id, int amountOfTickets);
        Task UpdateSeatsOnRemovedBookingSession(int id, int amountOfTickets);
        Task<IEnumerable<Session>> GetBookableSessionsToday();

        Task<IEnumerable<Session>> GetSessionsTodayAsync(int id);
        Task<Session> GetSessionById(int? id);
        Task Delete(Session session);
        Task Update(Session session);
    }
}
