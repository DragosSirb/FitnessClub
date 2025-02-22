using FitnessClub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessClub.Areas.Identity.Pages.Admin.Dashboard
{

    [Authorize(Roles ="admin")]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public int TotalMembers { get; set; }
        public decimal TotalRevenue { get; set; }
        public int ActiveMembers { get; set; }

        public void OnGet()
        {
            
            TotalMembers = _context.Members.Count();

          
            ActiveMembers = _context.Members.Count(m => m.SubscriptionStatus == "Active");

            TotalRevenue = _context.Members.Where(m => m.SubscriptionStatus == "Active")
                                           .Sum(m => m.SubscriptionExpiry.Year); 
        }
    }
}
