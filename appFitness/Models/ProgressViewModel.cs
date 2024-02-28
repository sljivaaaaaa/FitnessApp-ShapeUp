using System.ComponentModel.DataAnnotations;

namespace appFitness.Models
{
    public class ProgressViewModel
    {
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; }
    }
}
