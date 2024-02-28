using System;

namespace appFitness.Models
{
    public class Progress
    {
        public int ProgressId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
