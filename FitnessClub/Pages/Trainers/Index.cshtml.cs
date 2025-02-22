using FitnessClub.Data;
using FitnessClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using t = FitnessClub.Models.Trainers;
namespace FitnessClub.Pages.Trainers
{
    
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<t> Trainers { get; set; }

        public string SuccessMessage { get; set; }

        public async Task OnGetAsync()
        {
            Trainers = await _context.Trainers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
                await _context.SaveChangesAsync();

                SuccessMessage = "Trainer deleted successfully!";
            }

            return RedirectToPage();
        }
    }
}
