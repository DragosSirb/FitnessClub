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

namespace FitnessClub.Pages.Session
{
    public class IndexModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public IndexModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Sessions> Sessions { get;set; } = default!;
        public IList<T> Trainers { get;set; } = default!;
        public string SuccessMessage { get; set; }
        public async Task OnGetAsync()
        {
            Sessions = await _context.Sessions
                .Include(s => s.Member)
                .ToListAsync();

            var trainerIds = Sessions.Select(s => s.TrainerId).Distinct().ToList();

            Trainers = await _context.Trainers
                .Where(t => trainerIds.Contains(t.Id))
                .ToListAsync();
        }


        public IActionResult OnPostDelete(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                _context.SaveChanges();

                SuccessMessage = "Session deleted successfully.";
            }

            return RedirectToPage("./Index");
        }
    }
}
