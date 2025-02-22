using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.Subscriptions
{
    public class IndexModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public IndexModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Subscription> Subscription { get;set; } = default!;
        public string SuccessMessage { get; set; }
        public async Task OnGetAsync()
        {
            Subscription = await _context.Subscriptions
                .Include(s => s.Member).ToListAsync();
        }

        public IActionResult OnPostDelete(int id)
        {
            var subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                _context.SaveChanges();

                SuccessMessage = "Session deleted successfully."; 
            }

            return RedirectToPage("./Index");
        }
    }
}
