using FitnessClub.Data;
using FitnessClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessClub.Areas.Identity.Pages.Member.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public Members Member { get; set; }
        public List<Sessions> UpcomingSessions { get; set; }
        public List<BookedSessions> BookedSessions { get; set; }
        public List<Trainers> AvailableTrainers { get; set; }
        public List<Recommendations> Recommendations { get; set; }
        public List<MotivationalQotes> MotivationalQuotes { get; set; }
        [BindProperty]
        public double? Weight { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Console.WriteLine($"Current User ID: {currentUserId}");

            if (string.IsNullOrEmpty(currentUserId))
            {
            }

            var userSubscription = await _context.UserSubscriptions
                .Include(us => us.Subscription)
                .FirstOrDefaultAsync(us => us.UserId == currentUserId);

            if (userSubscription == null)
            {
            }

            var member = await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UserId == currentUserId);

            if (member == null)
            {
                Console.WriteLine($"Membru cu UserId {currentUserId} nu există în baza de date.");
               
            }

            Member = member;

            UpcomingSessions = await _context.Sessions
                .Where(s => s.MemberId == member.Id && s.Date > DateTime.Now)
                .OrderBy(s => s.Date)
                .ToListAsync();

            BookedSessions = await _context.BookedSessions
                .Where(bs => bs.MemberId == member.Id)
                .OrderBy(bs => bs.Date)
                .ToListAsync();

            AvailableTrainers = await _context.Trainers.ToListAsync();
            Recommendations = await _context.Recommendations.ToListAsync();
            MotivationalQuotes = await _context.MotivationalQotes.ToListAsync();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (Weight.HasValue)
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var member = await _context.Members
                    .FirstOrDefaultAsync(m => m.UserId == currentUserId);

                if (member != null)
                {
                    member.CurrentWeight = (decimal?)Weight.Value;

                    await _context.SaveChangesAsync();

                    return RedirectToPage();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCancelBookedSessionAsync(int id)
        {
            var session = await _context.BookedSessions.FindAsync(id);
            if (session != null)
            {
                _context.BookedSessions.Remove(session);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
