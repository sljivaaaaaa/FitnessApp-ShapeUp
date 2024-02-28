using System.ComponentModel.DataAnnotations;

namespace appFitness.Models
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
    }
}
