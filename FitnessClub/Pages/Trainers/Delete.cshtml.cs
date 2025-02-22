using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;
using T = FitnessClub.Models.Trainers;

namespace FitnessClub.Pages.Trainers
{
    public class DeleteModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public DeleteModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public T Trainers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers.FirstOrDefaultAsync(m => m.Id == id);

            if (trainers == null)
            {
                return NotFound();
            }
            else
            {
                Trainers = trainers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers != null)
            {
                Trainers = trainers;
                _context.Trainers.Remove(Trainers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
