namespace FitnessClub.Models
{
    public class MemberTrainer
    {

        public int Id { get; set; }

        public int MemberId { get; set; }
        public Members Member { get; set; }

        public int TrainerId { get; set; }
        public Trainers Trainer { get; set; }
    }
}
