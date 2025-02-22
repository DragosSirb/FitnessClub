using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClub.Models
{
    public class BookedSessions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TrainerId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [ForeignKey("TrainerId")]
        public Trainers? Trainer { get; set; }

        [ForeignKey("MemberId")]
        public Members? Member { get; set; }
    }
}
