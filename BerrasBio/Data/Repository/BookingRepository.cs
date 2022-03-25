using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Base
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;
        
        public BookingRepository(AppDbContext context) 
        {
            _context = context;
        }
        
        public async Task AddNewBooking(NewBookingViewModel booking)
        {
            var newBooking = new Booking()
            {
                AmountOfTickets = booking.AmountOfTickets,
                SessionId = booking.SessionId,
                MovieId = booking.MovieId
            };
            await _context.AddAsync(newBooking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync() =>  await _context.Bookings.Include(x => x.Session).Include(m => m.Movie).ToListAsync();
            
        public async Task<Booking> GetBookingByIdAsync(int id) => await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            
        
        public async Task<NewBookingDropdownVM> GetNewBookingDropdownVM()
        {
            var dropDown = new NewBookingDropdownVM()
            {
                Sessions = await _context.Sessions.OrderBy(x => x.Salon).ToListAsync(),
                Movies = await _context.Movies.OrderBy(x => x.Name).ToListAsync()
            };
            return dropDown;
        }
    }
}
