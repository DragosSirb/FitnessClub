using FitnessClub.Data;
using FitnessClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitnessClub.Pages.Subscriptions
{
    public class BuySubscriptionModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationMember> _userManager;
        private readonly ILogger<BuySubscriptionModel> _logger;

        // Injectarea serviciilor
        public BuySubscriptionModel(AppDbContext context, UserManager<ApplicationMember> userManager, ILogger<BuySubscriptionModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public List<Subscription> Subscriptions { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            _logger.LogInformation("Fetching available subscriptions.");
            Subscriptions = await _context.Subscriptions.ToListAsync();
            _logger.LogInformation($"Fetched {Subscriptions.Count} subscriptions.");
            return Page();
        }

        public async Task<IActionResult> OnPostSubscribeAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToPage("/Account/Login"); 
            }

            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            var existingSubscription = await _context.UserSubscriptions
                .FirstOrDefaultAsync(us => us.UserId == userId && us.Status == "Active");

            if (existingSubscription != null)
            {
                ErrorMessage = "You already have an active subscription!";
                return Page();
            }

            var newUserSubscription = new UserSubscription
            {
                UserId = userId,
                SubscriptionId = subscription.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Status = "Active"
            };

            _context.UserSubscriptions.Add(newUserSubscription);
            await _context.SaveChangesAsync(); 

            var member = await _context.Members.FirstOrDefaultAsync(m => m.UserId == userId);

            if (member != null)
            {
                member.SubscriptionStatus = "Active";
                member.SubscriptionExpiry = DateTime.Now.AddYears(1);

                await _context.SaveChangesAsync();
            }

            SuccessMessage = $"You have successfully subscribed to {subscription.SubscriptionType}!";
            return RedirectToPage("/Index");
        }


    }
}