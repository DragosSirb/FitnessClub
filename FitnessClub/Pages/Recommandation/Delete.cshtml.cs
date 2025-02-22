using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.Recommandation
{
    public class DeleteModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public DeleteModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recommendations Recommendations { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendations = await _context.Recommendations.FirstOrDefaultAsync(m => m.Id == id);

            if (recommendations == null)
            {
                return NotFound();
            }
            else
            {
                Recommendations = recommendations;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendations = await _context.Recommendations.FindAsync(id);
            if (recommendations != null)
            {
                Recommendations = recommendations;
                _context.Recommendations.Remove(Recommendations);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
