using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string Phone { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}

