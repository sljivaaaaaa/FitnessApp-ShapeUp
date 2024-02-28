using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appFitness.Models
{
    public class WorkoutImage
    {

        [Key]
        public int WorkoutImageId { get; set; }
        public int WorkoutId { get; set; }
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public virtual Workout Workout { get; set; }
    }
}
