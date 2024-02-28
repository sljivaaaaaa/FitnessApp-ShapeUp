using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appFitness.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanDays_MealPlans_MealPlanPlanId",
                table: "MealPlanDays");

            migrationBuilder.DropIndex(
                name: "IX_MealPlanDays_MealPlanPlanId",
                table: "MealPlanDays");

            migrationBuilder.DropColumn(
                name: "MealPlanPlanId",
                table: "MealPlanDays");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "MealPlanDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "MealPlanDayId",
                keyValue: 1,
                column: "MealPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "MealPlanDayId",
                keyValue: 2,
                column: "MealPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "MealPlanDayId",
                keyValue: 3,
                column: "MealPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "MealPlanDayId",
                keyValue: 4,
                column: "MealPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "MealPlanDayId",
                keyValue: 5,
                column: "MealPlanId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDays_MealPlanId",
                table: "MealPlanDays",
                column: "MealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanDays_MealPlans_MealPlanId",
                table: "MealPlanDays",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanDays_MealPlans_MealPlanId",
                table: "MealPlanDays");

            migrationBuilder.DropIndex(
                name: "IX_MealPlanDays_MealPlanId",
                table: "MealPlanDays");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "MealPlanDays");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanPlanId",
                table: "MealPlanDays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDays_MealPlanPlanId",
                table: "MealPlanDays",
                column: "MealPlanPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanDays_MealPlans_MealPlanPlanId",
                table: "MealPlanDays",
                column: "MealPlanPlanId",
                principalTable: "MealPlans",
                principalColumn: "PlanId");
        }
    }
}
