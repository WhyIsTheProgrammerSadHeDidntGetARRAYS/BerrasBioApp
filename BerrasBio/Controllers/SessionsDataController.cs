using BerrasBio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Controllers
{
    //Denna controllern är till för att hjälpa till att se dem gamla föreställningarna, datum och kunna plocka bort dem från db
    public class SessionsDataController : Controller
    {
        private readonly AppDbContext _context;
        // Note to self: Här orkade jag inte göra ett repositroy alls, för detta är bara så jag skulle kunna ta bort "gamla sessions"
        //eftersom jag bara visar sessioner/föreställningar som är aktiva, d.v.s föreställningar som går att boka. Då ligger
        //uteblivna föreställningar kvar i databasen, där av denna controllern

        public SessionsDataController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var oldSessions = _context.Sessions.Include(c => c.Cinema)
                .Include(m => m.Movie)
                .Include(s => s.Salon)
                .Where(x => x.StartDate < DateTime.Now);
            
            return View(oldSessions);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var oldSession = _context.Sessions.Include(c => c.Cinema)
                .Include(m => m.Movie)
                .Include(s => s.Salon)
                .Where(x => x.StartDate < DateTime.Now).FirstOrDefault();

            if (oldSession == null)
            {
                return NotFound();
            }

            return View(oldSession);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session2 = await _context.Sessions.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Sessions.Remove(session2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
