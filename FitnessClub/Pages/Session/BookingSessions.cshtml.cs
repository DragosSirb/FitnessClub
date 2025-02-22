using FitnessClub.Data;
using FitnessClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using T = FitnessClub.Models.Trainers;

namespace FitnessClub.Pages.Session
{
    public class BookingSessionsModel : PageModel
    {
        private readonly AppDbContext _context;

        public BookingSessionsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<T> AvailableTrainers { get; set; }
        public List<string> AvailableLocations { get; set; } = new List<string>(); // Lista locațiilor disponibile

        [BindProperty]
        public int TrainerId { get; set; }

        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public string Location { get; set; }

        public async Task OnGetAsync()
        {
            AvailableTrainers = await _context.Trainers.ToListAsync();

            AvailableLocations = await _context.Sessions
                .Select(s => s.Location)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.UserId == currentUserId);

            if (member == null)
            {
                return RedirectToPage("/Error");
            }

            var bookedSession = new BookedSessions
            {
                MemberId = member.Id,
                TrainerId = TrainerId,
                Date = Date,
                Location = Location,
                Status = "Pending"
            };

            _context.BookedSessions.Add(bookedSession);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
