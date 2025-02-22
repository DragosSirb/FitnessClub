using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.Session
{
    public class DeleteModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public DeleteModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sessions Sessions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions.FirstOrDefaultAsync(m => m.Id == id);

            if (sessions == null)
            {
                return NotFound();
            }
            else
            {
                Sessions = sessions;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions.FindAsync(id);
            if (sessions != null)
            {
                Sessions = sessions;
                _context.Sessions.Remove(Sessions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
