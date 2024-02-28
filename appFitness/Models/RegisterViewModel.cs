// RegisterViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace appFitness.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int Age { get; set; }
        public string Goal { get; set; }
        public string Gender { get; set; }
    }
}
