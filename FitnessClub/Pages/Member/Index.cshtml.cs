using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Data;
using FitnessClub.Models;

namespace FitnessClub.Pages.Member
{
    public class IndexModel : PageModel
    {
        private readonly FitnessClub.Data.AppDbContext _context;

        public IndexModel(FitnessClub.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Members> Members { get;set; } = default!;

        public string SuccessMessage { get; set; }
        public async Task OnGetAsync()
        {
            Members = await _context.Members
                .Include(m => m.User).ToListAsync();
        }

        public IActionResult OnPostDelete(int id)
        {
            var member = _context.Members.FirstOrDefault(s => s.Id == id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();

                SuccessMessage = "Session deleted successfully.";
            }

            return RedirectToPage("./Index");
        }
    }
}
