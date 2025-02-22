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
using T = FitnessClub.Models.Trainers;

namespace FitnessClub.Pages.Trainers
{
    public class EditModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public EditModel(FitnessClub.Data.AppDbContext context)
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

            var trainers =  await _context.Trainers.FirstOrDefaultAsync(m => m.Id == id);
            if (trainers == null)
            {
                return NotFound();
            }
            Trainers = trainers;
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

            _context.Attach(Trainers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainersExists(Trainers.Id))
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

        private bool TrainersExists(int id)
        {
            return _context.Trainers.Any(e => e.Id == id);
        }
    }
}
