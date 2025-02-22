using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.MotivationalQote
{
    public class IndexModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public IndexModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<MotivationalQotes> MotivationalQotes { get;set; } = default!;

        public string SuccessMessage { get; set; }
        public async Task OnGetAsync()
        {
            MotivationalQotes = await _context.MotivationalQotes.ToListAsync();
        }

        public IActionResult OnPostDelete(int id)
        {
            var motivational = _context.MotivationalQotes.FirstOrDefault(s => s.Id == id);
            if (motivational != null)
            {
                _context.MotivationalQotes.Remove(motivational);
                _context.SaveChanges();

                SuccessMessage = "Session deleted successfully.";
            }

            return RedirectToPage("./Index");
        }
    }
}
