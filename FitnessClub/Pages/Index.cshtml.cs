using FitnessClub.Data;
using FitnessClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T = FitnessClub.Models.Trainers;

namespace FitnessClub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Subscription> Subscriptions { get; set; }
        public IEnumerable<T> Trainers { get; set; }
        public IEnumerable<Sessions> Sessions { get; set; }

        public async Task OnGet()
        {
            Subscriptions = await _context.Subscriptions.ToListAsync();
            Trainers = await _context.Trainers.ToListAsync();
            Sessions = await _context.Sessions.ToListAsync();
        }
    }
}
