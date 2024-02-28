using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFitness.Models
{
    public class MealPlanDay
    {
        [Key]
        public int MealPlanDayId { get; set; }
        public string DayOfWeek { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string Snack { get; set; }
        public int MealPlanId { get; set; }

        [ForeignKey("MealPlanId")]
        public MealPlan MealPlan { get; set; }
    }
}
