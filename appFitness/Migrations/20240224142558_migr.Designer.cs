﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using appFitness.Data;

#nullable disable

namespace appFitness.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240224142558_migr")]
    partial class migr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("appFitness.Models.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MealId"), 1L, 1);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MealId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("appFitness.Models.MealPlan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MondayId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TuesdayId")
                        .HasColumnType("int");

                    b.HasKey("PlanId");

                    b.ToTable("MealPlans");

                    b.HasData(
                        new
                        {
                            PlanId = 1,
                            Description = "A meal plan focused on vegetarian options.",
                            MondayId = 1,
                            Title = "Vegetarian Meal Plan",
                            TuesdayId = 2
                        },
                        new
                        {
                            PlanId = 2,
                            Description = "A meal plan focused on ketogenic options.",
                            MondayId = 3,
                            Title = "Keto Meal Plan",
                            TuesdayId = 4
                        });
                });

            modelBuilder.Entity("appFitness.Models.MealPlanDay", b =>
                {
                    b.Property<int>("MealPlanDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MealPlanDayId"), 1L, 1);

                    b.Property<string>("Breakfast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dinner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lunch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MealPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Snack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MealPlanDayId");

                    b.HasIndex("MealPlanId");

                    b.ToTable("MealPlanDays");

                    b.HasData(
                        new
                        {
                            MealPlanDayId = 1,
                            Breakfast = "Oatmeal with fruits",
                            DayOfWeek = "Monday",
                            Dinner = "Stir-fried vegetables with tofu",
                            Lunch = "Quinoa salad",
                            MealPlanId = 1,
                            Snack = "Greek yogurt with nuts"
                        },
                        new
                        {
                            MealPlanDayId = 2,
                            Breakfast = "Avocado toast",
                            DayOfWeek = "Tuesday",
                            Dinner = "Grilled portobello mushrooms",
                            Lunch = "Vegetable curry",
                            MealPlanId = 1,
                            Snack = "Hummus with veggies"
                        },
                        new
                        {
                            MealPlanDayId = 3,
                            Breakfast = "Scrambled eggs with spinach",
                            DayOfWeek = "Wednesday",
                            Dinner = "Baked salmon with roasted vegetables",
                            Lunch = "Quinoa and black bean tacos",
                            MealPlanId = 1,
                            Snack = "Apple slices with peanut butter"
                        },
                        new
                        {
                            MealPlanDayId = 4,
                            Breakfast = "Greek yogurt with granola and berries",
                            DayOfWeek = "Thursday",
                            Dinner = "Chicken stir-fry with brown rice",
                            Lunch = "Mediterranean chickpea salad",
                            MealPlanId = 1,
                            Snack = "Carrot sticks with hummus"
                        },
                        new
                        {
                            MealPlanDayId = 5,
                            Breakfast = "Whole grain toast with avocado and poached egg",
                            DayOfWeek = "Friday",
                            Dinner = "Grilled chicken breast with sweet potato fries",
                            Lunch = "Vegetable stir-fry with tofu",
                            MealPlanId = 1,
                            Snack = "Cottage cheese with pineapple chunks"
                        });
                });

            modelBuilder.Entity("appFitness.Models.Progress", b =>
                {
                    b.Property<int>("ProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("ProgressId");

                    b.HasIndex("UserId");

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("appFitness.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("appFitness.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutId");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            WorkoutId = 1,
                            Description = "Experience a dynamic, heart-pounding workout designed to maximize fat burn and boost your metabolism. Short, intense bursts of exercise followed by brief rest periods will push your limits and leave you feeling energized.",
                            Duration = "2 weeks",
                            Image = "/images/hiit1.jfif",
                            Level = "Beginner",
                            Title = "HIIT"
                        },
                        new
                        {
                            WorkoutId = 2,
                            Description = "Immerse yourself in the fluid movements of power yoga. This program combines strength, flexibility, and mindfulness, offering a holistic approach to fitness. ",
                            Duration = "2 months",
                            Image = "/images/yoga-gettyimages-1204500395-16-9.jpg",
                            Level = "Intermediate",
                            Title = "Power Yoga Flow"
                        },
                        new
                        {
                            WorkoutId = 3,
                            Description = "Embrace the intensity of CrossFit with a diverse circuit that targets all aspects of fitness",
                            Duration = "3 weeks",
                            Image = "/images/crosfit.jfif",
                            Level = "Advanced",
                            Title = "CrossFit Circuit"
                        },
                        new
                        {
                            WorkoutId = 4,
                            Description = "Get your heart pumping and your body moving with our Aerobic program. Designed to improve cardiovascular health and endurance, this energetic workout combines rhythmic movements with music to keep you motivated and having fun.",
                            Duration = "3 months",
                            Image = "/images/aerobic.jpg",
                            Level = "Intermediate",
                            Title = "Aerobic"
                        },
                        new
                        {
                            WorkoutId = 5,
                            Description = "Sculpt and tone your body with our Strength Workout program. Focused on building muscle and enhancing overall strength, this routine incorporates a mix of resistance training exercises to help you achieve your fitness goals.",
                            Duration = "1 month",
                            Image = "/images/str.jfif",
                            Level = "Intermediate",
                            Title = "Strength Workout"
                        },
                        new
                        {
                            WorkoutId = 6,
                            Description = "Utilize the power of suspension training with TRX Total Body. This program challenges your stability and strength through a variety of exercises, providing a full-body workout that targets muscles you never knew you had.",
                            Duration = "1 month",
                            Image = "/images/trx.jpg",
                            Level = "Intermediate",
                            Title = "TRX Total Body"
                        },
                        new
                        {
                            WorkoutId = 7,
                            Description = "No equipment? No problem! Bodyweight Blitz is a high-intensity program that uses your own body resistance to build strength and endurance",
                            Duration = "1 month",
                            Image = "/images/bodyweight.jpg",
                            Level = "Intermediate",
                            Title = "Bodyweight Blitz"
                        });
                });

            modelBuilder.Entity("appFitness.Models.WorkoutImage", b =>
                {
                    b.Property<int>("WorkoutImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutImageId"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutImageId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutImages");

                    b.HasData(
                        new
                        {
                            WorkoutImageId = 1,
                            ImageUrl = "/images/yoga-gettyimages-1204500395-16-9.jpg",
                            WorkoutId = 1
                        },
                        new
                        {
                            WorkoutImageId = 2,
                            ImageUrl = "/images/bodyweight.jpg",
                            WorkoutId = 1
                        },
                        new
                        {
                            WorkoutImageId = 3,
                            ImageUrl = "/images/trx.jpg",
                            WorkoutId = 1
                        });
                });

            modelBuilder.Entity("appFitness.Models.WorkoutLink", b =>
                {
                    b.Property<int>("WorkoutLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutLinkId"), 1L, 1);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutLinkId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutLinks");

                    b.HasData(
                        new
                        {
                            WorkoutLinkId = 1,
                            Url = "https://example.com/power-yoga-flow-video",
                            WorkoutId = 2
                        },
                        new
                        {
                            WorkoutLinkId = 2,
                            Url = "https://www.youtube.com/watch?v=Av7yZ_2yl2A",
                            WorkoutId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("appFitness.Models.MealPlanDay", b =>
                {
                    b.HasOne("appFitness.Models.MealPlan", "MealPlan")
                        .WithMany("Days")
                        .HasForeignKey("MealPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealPlan");
                });

            modelBuilder.Entity("appFitness.Models.Progress", b =>
                {
                    b.HasOne("appFitness.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("appFitness.Models.WorkoutImage", b =>
                {
                    b.HasOne("appFitness.Models.Workout", "Workout")
                        .WithMany("WorkoutImages")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("appFitness.Models.WorkoutLink", b =>
                {
                    b.HasOne("appFitness.Models.Workout", "Workout")
                        .WithMany("WorkoutLinks")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("appFitness.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("appFitness.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("appFitness.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("appFitness.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("appFitness.Models.MealPlan", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("appFitness.Models.Workout", b =>
                {
                    b.Navigation("WorkoutImages");

                    b.Navigation("WorkoutLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
