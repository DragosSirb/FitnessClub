using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessClub.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Subscription Type")]
        public string SubscriptionType { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } 

       
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        public int? MemberId { get; set; }

        public  Members? Member { get; set; }
    }
}
