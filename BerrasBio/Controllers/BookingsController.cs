﻿using BerrasBio.Data.Base;
using BerrasBio.Data.Interfaces;
using BerrasBio.Data.Services;
using BerrasBio.Data.ViewModels;
using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BerrasBio.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(ISessionRepository sessionRepository, IBookingRepository bookingRepository)
        {
            _sessionRepository = sessionRepository;
            _bookingRepository = bookingRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _bookingRepository.GetAllBookingsAsync());
        }
        /// <summary>
        /// Created my own dropdown, from GetNewBookingdropdownvm method, and ensures that the user
        /// also cannot book a movie for a date that has passed the current date/time
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Create(int id)
        {
            var bookingData = await _bookingRepository.GetNewBookingDropdownVM();
            ViewBag.Sessions = new SelectList(
                bookingData.Sessions
                .Where(x => x.StartDate >= DateTime.Now && x.MovieId == id && x.AvailableSeats > 0), "Id", "StartDate");

            ViewBag.Movies = new SelectList(bookingData.Movies.Where(x => x.Id == id), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBookingViewModel booking)
        {
            var sessionData = await _sessionRepository.GetSessionById(booking.SessionId);
            if (!ModelState.IsValid)
            {
                return View(booking);
            }
            if (sessionData.AvailableSeats < booking.AmountOfTickets)
            {
                return View("BookingFail");
            }
            await _bookingRepository.AddNewBooking(booking);
            await _sessionRepository.UpdateSessionseatsOnNewBooking(booking.SessionId, booking.AmountOfTickets);
            return View("BookingComplete");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deleteBooking = await _bookingRepository.GetBookingByIdAsync(id);

            if (deleteBooking == null) { return View(id); }

            await _bookingRepository.DeleteBooking(id);
            await _sessionRepository.UpdateSessionseatsOnRemovedBooking(deleteBooking.SessionId, deleteBooking.AmountOfTickets);
            return RedirectToAction(nameof(Index));

        }
    }
}
