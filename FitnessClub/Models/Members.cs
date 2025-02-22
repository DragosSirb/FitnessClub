using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FitnessClub.Models
{
    public class Members
    {
    
        public string UserId { get; set; } 
        public virtual ApplicationMember User { get; set; }

        public int Id { get; set; }
        public string MemberName { get; set; }
        public string SubscriptionStatus { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        public decimal? CurrentWeight { get; set; }
        public ICollection<Sessions>? ScheduledSessions { get; set; } = new List<Sessions>();
        public ICollection<MemberTrainer>? MemberTrainers { get; set; } = new List<MemberTrainer>();
        public ICollection<Recommendations>? Recommendations { get; set; } = new List<Recommendations>();
        public ICollection<MotivationalQotes>? MotivationalQotes { get; set; } = new List<MotivationalQotes>();

    }
}
