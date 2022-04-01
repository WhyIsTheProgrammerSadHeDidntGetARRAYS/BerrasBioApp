#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Data;
using BerrasBio.Models;
using BerrasBio.Data.Services;
using BerrasBio.Data.Interfaces;
using BerrasBio.Data.ViewModels;

namespace BerrasBio.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ISalonRepository _salonRepository;

        public SessionsController(ISessionRepository service, ISalonRepository salonRepository)
        {
            _sessionRepository = service;
            _salonRepository = salonRepository;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var sessions = await _sessionRepository.GetBookableSessionsToday(); //meaning the time has not passed the current time right now
            return View(sessions);
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var session = await _sessionRepository.GetSessionById(id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }
        public async Task<IActionResult> Create(int id)
        {
            var sessionData = await _sessionRepository.GetNewSessionDropdown();
            ViewData["CinemaId"] = new SelectList(sessionData.Cinemas, "Id", "Name");
            ViewData["MovieId"] = new SelectList(sessionData.Movies, "Id", "Name");
            ViewData["SalonId"] = new SelectList(sessionData.Salons, "Id", "SalonName");
            return View();
        }

        //POST: Sessions/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,MovieId,CinemaId,SalonId")] Session session)
        {
            if (ModelState.IsValid)
            {
                // TODO: Vill gärna tro att den här biten kanske kunde varit ett jobb för en service(när man blandar in fler entiter egentligen, för det blir ju lite att man manipulerar datan i objekt form aka business logic) , men fuck it
                var test = await _salonRepository.GetSalonById(session.SalonId);
                session.AvailableSeats = test.TotalSeats;
                await _sessionRepository.AddNewSession(session);
                return RedirectToAction(nameof(Index));
            }
            var sessionData = await _sessionRepository.GetNewSessionDropdown();
            ViewData["CinemaId"] = new SelectList(sessionData.Cinemas, "Id", "Name");
            ViewData["MovieId"] = new SelectList(sessionData.Movies, "Id", "Name");
            ViewData["SalonId"] = new SelectList(sessionData.Salons, "Id", "SalonName");
            return View(session);
        }

        // GET: Sessions/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _sessionRepository.GetSessionById(id);
            if (session == null)
            {
                return NotFound();
            }
            var sessionData = await _sessionRepository.GetNewSessionDropdown();
            ViewData["CinemaId"] = new SelectList(sessionData.Cinemas, "Id", "Name");
            ViewData["MovieId"] = new SelectList(sessionData.Movies, "Id", "Name");
            ViewData["SalonId"] = new SelectList(sessionData.Salons, "Id", "SalonName");
            return View(session);
        }
        //TODO: Fixa så att denna metoden använder sig av repository(skulle varit services egentligen men w/e)
        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,AvailableSeats,MovieId,CinemaId,SalonId")] Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }
            var salon = await _salonRepository.GetSalonById(session.SalonId);

            if (!ModelState.IsValid || session.AvailableSeats > salon.TotalSeats || session.AvailableSeats < 1)
            {
                var sessionData = await _sessionRepository.GetNewSessionDropdown();
                ViewData["CinemaId"] = new SelectList(sessionData.Cinemas, "Id", "Name");
                ViewData["MovieId"] = new SelectList(sessionData.Movies, "Id", "Name");
                ViewData["SalonId"] = new SelectList(sessionData.Salons, "Id", "SalonName");
                return View(session);
            }
            try
            {
                await _sessionRepository.Update(session);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var session = await _sessionRepository.GetSessionById(id);

            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session2 = await _sessionRepository.GetSessionById(id);
            await _sessionRepository.Delete(session2);
            return RedirectToAction(nameof(Index));
        }

    }
}
