namespace FitnessClub.Models
{
    public class UserSubscription
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public int SubscriptionId { get; set; } 
        
        public Subscription? Subscription { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }  
        public string Status { get; set; }

    }

}
