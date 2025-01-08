using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }

        [Required(ErrorMessage = "Workout name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Instructor is required.")]
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
    }
}
