using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Reservation
    {
            public int ReservationId { get; set; }

            [Required(ErrorMessage = "Member is required.")]
            public int MemberId { get; set; }
            public Member Member { get; set; }

            [Required(ErrorMessage = "Workout is required.")]
            public int WorkoutId { get; set; }
            public Workout Workout { get; set; }

            public DateTime ReservationTime { get; set; }
        }
}
