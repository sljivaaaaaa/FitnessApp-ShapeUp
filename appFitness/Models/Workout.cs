using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFitness.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
            public virtual ICollection<WorkoutImage> WorkoutImages { get; set; }
        public virtual ICollection<WorkoutLink> WorkoutLinks { get; set; }
    }
}