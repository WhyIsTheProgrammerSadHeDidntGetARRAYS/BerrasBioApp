using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Base
{
    public interface IBookingRepository 
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task AddNewBooking(NewBookingViewModel booking);
        Task<NewBookingDropdownVM> GetNewBookingDropdownVM();
        Task DeleteBooking(int id);

    }
}
