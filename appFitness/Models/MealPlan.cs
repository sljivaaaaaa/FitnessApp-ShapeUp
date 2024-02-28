using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace appFitness.Models
{
    public class MealPlan
    {
        [Key]
        public int PlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MondayId { get; set; } 
        public int TuesdayId { get; set; }
        public int WendesdayId { get; set; }
        public int ThursdayId { get; set; }
        public int FridayId { get; set; }
        public int SaturdayId { get; set; }
        public int SundayId { get; set; }
        public List<MealPlanDay> Days { get; set; }
    }
}
