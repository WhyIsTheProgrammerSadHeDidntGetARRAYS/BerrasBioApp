using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.ViewModels
{
    public class NewBookingViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Ticket amount")]
        [Range(1, 12, ErrorMessage = "You can only order 1-12 tickets per purchase.")]
        public int AmountOfTickets { get; set; }

        [Display(Name ="Active Sessions")]
        [Required(ErrorMessage = "Session is required to book a ticket. If you don't see any sessions for this movie, navigate to the Session tab, and see what movies we're currently showing'")]
        public int SessionId { get; set; }// we are gonna display time of the SessionId in question
        [Display(Name ="Your movie of choice.")]
        public int MovieId { get; set; } // we are gonna display the movie name that was clicked on from the "book a ticket" button
    }
}
