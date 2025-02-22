using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.Recommandation
{
    public class EditModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public EditModel(FitnessClub.Data.AppDbContext context)
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

            var recommendations =  await _context.Recommendations.FirstOrDefaultAsync(m => m.Id == id);
            if (recommendations == null)
            {
                return NotFound();
            }
            Recommendations = recommendations;
           ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recommendations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommendationsExists(Recommendations.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecommendationsExists(int id)
        {
            return _context.Recommendations.Any(e => e.Id == id);
        }
    }
}
