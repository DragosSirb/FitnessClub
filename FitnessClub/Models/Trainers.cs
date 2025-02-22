namespace FitnessClub.Models
{
    public class Trainers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }

        public string Description { get; set; }
        public int? MemberId { get; set; }
        public Members? Member { get; set; }

        public ICollection<MemberTrainer>? MemberTrainers { get; set; } = new List<MemberTrainer>();

    }

}
