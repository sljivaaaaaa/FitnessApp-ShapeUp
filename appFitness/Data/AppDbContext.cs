using appFitness.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace appFitness.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutImage> WorkoutImages { get; set; }
        public DbSet<WorkoutLink> WorkoutLinks { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Progress> Progress { get; set; }

        public DbSet<MealPlanDay> MealPlanDays { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
    .Property(u => u.Id)
    .ValueGeneratedOnAdd()
    .HasDefaultValueSql("NEWID()");


      
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.WorkoutImages)
                .WithOne(wi => wi.Workout)
                .HasForeignKey(wi => wi.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Workout>()
                .HasMany(w => w.WorkoutLinks)
                .WithOne(wl => wl.Workout)
                .HasForeignKey(wl => wl.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Workout>().HasData(
                new List<Workout>
                {

new Workout
{
    WorkoutId = 1,
    Title = "HIIT",
    Description = "Experience a dynamic, heart-pounding workout designed to maximize fat burn and boost your metabolism. Short, intense bursts of exercise followed by brief rest periods will push your limits and leave you feeling energized.",
    Image = "/images/hiit1.jfif",
    Duration = "2 weeks",
    Level = "Beginner",
},
new Workout
{
    WorkoutId = 2,
    Title = "Power Yoga Flow",
    Description = "Immerse yourself in the fluid movements of power yoga. This program combines strength, flexibility, and mindfulness, offering a holistic approach to fitness. ",
    Image = "/images/yoga-gettyimages-1204500395-16-9.jpg",
    Duration = "2 months",
    Level = "Intermediate",
},
new Workout
{
    WorkoutId = 3,
    Title = "CrossFit Circuit",
    Description = "Embrace the intensity of CrossFit with a diverse circuit that targets all aspects of fitness",
    Image = "/images/crosfit.jfif",
    Duration = "3 weeks",
    Level = "Advanced",
},
new Workout
{
    WorkoutId = 4,
    Title = "Aerobic",
    Description = "Get your heart pumping and your body moving with our Aerobic program. Designed to improve cardiovascular health and endurance, this energetic workout combines rhythmic movements with music to keep you motivated and having fun.",
    Image = "/images/aerobic.jpg",
    Duration = "3 months",
    Level = "Intermediate",
},
new Workout
{
    WorkoutId = 5,
    Title = "Strength Workout",
    Description = "Sculpt and tone your body with our Strength Workout program. Focused on building muscle and enhancing overall strength, this routine incorporates a mix of resistance training exercises to help you achieve your fitness goals.",
    Image = "/images/str.jfif",
    Duration = "1 month",
    Level = "Intermediate",
},
new Workout
{
    WorkoutId = 6,
    Title = "TRX Total Body",
    Description = "Utilize the power of suspension training with TRX Total Body. This program challenges your stability and strength through a variety of exercises, providing a full-body workout that targets muscles you never knew you had.",
    Image = "/images/trx.jpg",
    Duration = "1 month",
    Level = "Intermediate",
},
new Workout
{
    WorkoutId = 7,
    Title = "Bodyweight Blitz",
    Description = "No equipment? No problem! Bodyweight Blitz is a high-intensity program that uses your own body resistance to build strength and endurance",
    Image = "/images/bodyweight.jpg",
    Duration = "1 month",
    Level = "Intermediate",
},

                }
            );

 
            modelBuilder.Entity<WorkoutImage>().HasData(
                new List<WorkoutImage>
                {
                   // Your WorkoutImage seed data here...
new WorkoutImage { WorkoutImageId = 1, WorkoutId = 1, ImageUrl = "/images/yoga-gettyimages-1204500395-16-9.jpg" },
new WorkoutImage { WorkoutImageId = 2, WorkoutId = 1, ImageUrl = "/images/bodyweight.jpg" },
new WorkoutImage { WorkoutImageId = 3, WorkoutId = 1, ImageUrl = "/images/trx.jpg" },
// Add more image URLs as needed

                }
            );

    
            modelBuilder.Entity<WorkoutLink>().HasData(
                new List<WorkoutLink>
                {
   
new WorkoutLink { WorkoutLinkId = 1, WorkoutId = 2, Url = "https://example.com/power-yoga-flow-video" },
new WorkoutLink { WorkoutLinkId = 2, WorkoutId = 2, Url = "https://www.youtube.com/watch?v=Av7yZ_2yl2A" },


                }
            );

            modelBuilder.Entity<MealPlan>().HasData(
                new List<MealPlan>
                {
        new MealPlan
        {
            PlanId = 1,
            Title = "Vegetarian Meal Plan",
            Description = "A meal plan focused on vegetarian options.",
            MondayId = 1,
            TuesdayId = 2,
            // Add more days as needed
        },
        new MealPlan
        {
            PlanId = 2,
            Title = "Keto Meal Plan",
            Description = "A meal plan focused on ketogenic options.",
            MondayId = 3,
            TuesdayId = 4,
            // Add more days as needed
        },
                    // Add more meal plans as needed
                }
            );

            // Seed initial data for MealPlanDays
            modelBuilder.Entity<MealPlanDay>().HasData(
                new List<MealPlanDay>
                {
        new MealPlanDay
        {
            MealPlanDayId = 1,
            DayOfWeek = "Monday",
            Breakfast = "Oatmeal with fruits",
            Lunch = "Quinoa salad",
            Dinner = "Stir-fried vegetables with tofu",
            Snack = "Greek yogurt with nuts",
            MealPlanId = 1, // Specify the corresponding MealPlanId
        },
        new MealPlanDay
        {
            MealPlanDayId = 2,
            DayOfWeek = "Tuesday",
            Breakfast = "Avocado toast",
            Lunch = "Vegetable curry",
            Dinner = "Grilled portobello mushrooms",
            Snack = "Hummus with veggies",
            MealPlanId = 1, // Specify the corresponding MealPlanId
        },
        new MealPlanDay
        {
            MealPlanDayId = 3,
            DayOfWeek = "Wednesday",
            Breakfast = "Scrambled eggs with spinach",
            Lunch = "Quinoa and black bean tacos",
            Dinner = "Baked salmon with roasted vegetables",
            Snack = "Apple slices with peanut butter",
            MealPlanId = 1, // Specify the corresponding MealPlanId
        },
        new MealPlanDay
        {
            MealPlanDayId = 4,
            DayOfWeek = "Thursday",
            Breakfast = "Greek yogurt with granola and berries",
            Lunch = "Mediterranean chickpea salad",
            Dinner = "Chicken stir-fry with brown rice",
            Snack = "Carrot sticks with hummus",
            MealPlanId = 1, // Specify the corresponding MealPlanId
        },
        new MealPlanDay
        {
            MealPlanDayId = 5,
            DayOfWeek = "Friday",
            Breakfast = "Whole grain toast with avocado and poached egg",
            Lunch = "Vegetable stir-fry with tofu",
            Dinner = "Grilled chicken breast with sweet potato fries",
            Snack = "Cottage cheese with pineapple chunks",
            MealPlanId = 1, // Specify the corresponding MealPlanId
        },
                    // Add more meal plan days as needed
                }
            );

        }
    }
}
