using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appFitness.Migrations
{
    public partial class mealplans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MondayId",
                table: "MealPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayId",
                table: "MealPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MealPlanDays",
                columns: table => new
                {
                    MealPlanDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lunch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dinner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Snack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealPlanPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanDays", x => x.MealPlanDayId);
                    table.ForeignKey(
                        name: "FK_MealPlanDays_MealPlans_MealPlanPlanId",
                        column: x => x.MealPlanPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "PlanId");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                });

            migrationBuilder.InsertData(
                table: "MealPlanDays",
                columns: new[] { "MealPlanDayId", "Breakfast", "DayOfWeek", "Dinner", "Lunch", "MealPlanPlanId", "Snack" },
                values: new object[,]
                {
                    { 1, "Oatmeal with fruits", "Monday", "Stir-fried vegetables with tofu", "Quinoa salad", null, "Greek yogurt with nuts" },
                    { 2, "Avocado toast", "Tuesday", "Grilled portobello mushrooms", "Vegetable curry", null, "Hummus with veggies" },
                    { 3, "Scrambled eggs with spinach", "Wednesday", "Baked salmon with roasted vegetables", "Quinoa and black bean tacos", null, "Apple slices with peanut butter" },
                    { 4, "Greek yogurt with granola and berries", "Thursday", "Chicken stir-fry with brown rice", "Mediterranean chickpea salad", null, "Carrot sticks with hummus" },
                    { 5, "Whole grain toast with avocado and poached egg", "Friday", "Grilled chicken breast with sweet potato fries", "Vegetable stir-fry with tofu", null, "Cottage cheese with pineapple chunks" }
                });

            migrationBuilder.InsertData(
                table: "MealPlans",
                columns: new[] { "PlanId", "Description", "MondayId", "Title", "TuesdayId" },
                values: new object[,]
                {
                    { 1, "A meal plan focused on vegetarian options.", 1, "Vegetarian Meal Plan", 2 },
                    { 2, "A meal plan focused on ketogenic options.", 3, "Keto Meal Plan", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDays_MealPlanPlanId",
                table: "MealPlanDays",
                column: "MealPlanPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanDays");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "PlanId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "PlanId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "MondayId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "TuesdayId",
                table: "MealPlans");
        }
    }
}
