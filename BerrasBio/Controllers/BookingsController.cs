using BerrasBio.Data.Services;
using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;

namespace BerrasBio.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ISessionService _sessionService;

        public BookingsController(IBookingService bookingService, ISessionService sessionService)
        {
            _bookingService = bookingService;
            _sessionService = sessionService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _bookingService.GetAllBookings());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (!ModelState.IsValid || booking.AmountOfTickets < 1)
            {
                return View(booking);
            }
            _bookingService.AddAsync(booking);
            return RedirectToAction("Index");
        }
    }
}
