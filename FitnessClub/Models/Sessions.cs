using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessClub.Models
{
    public class Sessions
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        public string Description { get; set; }

        public int? MemberId { get; set; }
        public Members? Member { get; set; }

        [Required(ErrorMessage = "TrainerId is required.")]
        public int? TrainerId { get; set; }

        public Trainers? Trainers { get; set; }
    }
}
