using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appFitness.Migrations
{
    public partial class models3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkoutImages",
                keyColumn: "WorkoutImageId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/yoga-gettyimages-1204500395-16-9.jpg");

            migrationBuilder.UpdateData(
                table: "WorkoutImages",
                keyColumn: "WorkoutImageId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/bodyweight.jpg");

            migrationBuilder.InsertData(
                table: "WorkoutImages",
                columns: new[] { "WorkoutImageId", "ImageUrl", "WorkoutId" },
                values: new object[] { 3, "/images/trx.jpg", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutImages",
                keyColumn: "WorkoutImageId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "WorkoutImages",
                keyColumn: "WorkoutImageId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/hiit1_1.jpg");

            migrationBuilder.UpdateData(
                table: "WorkoutImages",
                keyColumn: "WorkoutImageId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/hiit1_2.jpg");
        }
    }
}
