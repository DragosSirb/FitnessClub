using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.Recommandation
{
    public class CreateModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public CreateModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Recommendations Recommendations { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recommendations.Add(Recommendations);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
