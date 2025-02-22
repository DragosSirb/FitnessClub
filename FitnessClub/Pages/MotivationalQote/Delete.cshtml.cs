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
    public class DeleteModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public DeleteModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MotivationalQotes MotivationalQotes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivationalqotes = await _context.MotivationalQotes.FirstOrDefaultAsync(m => m.Id == id);

            if (motivationalqotes == null)
            {
                return NotFound();
            }
            else
            {
                MotivationalQotes = motivationalqotes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivationalqotes = await _context.MotivationalQotes.FindAsync(id);
            if (motivationalqotes != null)
            {
                MotivationalQotes = motivationalqotes;
                _context.MotivationalQotes.Remove(MotivationalQotes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
