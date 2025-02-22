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
    public class IndexModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public IndexModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Recommendations> Recommendations { get;set; } = default!;

        public string SuccessMessage { get; set; }
        public async Task OnGetAsync()
        {
            Recommendations = await _context.Recommendations.ToListAsync();
        }

        public IActionResult OnPostDelete(int id)
        {
            var recommendations = _context.Recommendations.FirstOrDefault(s => s.Id == id);
            if (recommendations != null)
            {
                _context.Recommendations.Remove(recommendations);
                _context.SaveChanges();

                SuccessMessage = "Session deleted successfully.";
            }

            return RedirectToPage("./Index");
        }
    }
}
