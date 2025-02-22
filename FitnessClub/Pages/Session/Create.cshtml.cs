using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessClub.Data;
using FitnessClub.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FitnessClub.Pages.Session
{
    public class CreateModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public CreateModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sessions Sessions { get; set; }

        public IActionResult OnGet()
        {
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Name");
            return Page();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Debugging ModelState errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);

                    Console.WriteLine("TRAINERIDD!1!!: " + Sessions.TrainerId);
                }

                return Page();
            }

            _context.Sessions.Add(Sessions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }





    }
}
