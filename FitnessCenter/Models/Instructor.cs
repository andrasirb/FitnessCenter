using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(200, ErrorMessage = "Specialization cannot be longer than 200 characters.")]
        public string Specialization { get; set; }

        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}

