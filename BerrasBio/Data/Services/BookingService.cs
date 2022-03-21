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
    public class BookingService : GenericRepository<Booking>, IBookingService
    {
        private readonly AppDbContext _context;
        public BookingService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task AddNewBooking(Booking newBooking)
        //{
        //    var booking = new Booking()
        //    {

        //    }
        //}

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = await _context.Bookings.Include(x => x.Session).Include(m => m.Movie).ToListAsync();
            return bookings;
        }
    }
}
