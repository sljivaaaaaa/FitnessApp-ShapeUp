using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFitness.Models
{
    public class WorkoutLink
    {
    
        
            [Key]
            public int WorkoutLinkId { get; set; }
            public int WorkoutId { get; set; }
            public string Url { get; set; }
            public virtual Workout Workout { get; set; }
        
    }
}
