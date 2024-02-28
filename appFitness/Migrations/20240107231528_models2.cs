using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appFitness.Migrations
{
    public partial class models2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutImages",
                columns: table => new
                {
                    WorkoutImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutImages", x => x.WorkoutImageId);
                    table.ForeignKey(
                        name: "FK_WorkoutImages_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLinks",
                columns: table => new
                {
                    WorkoutLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLinks", x => x.WorkoutLinkId);
                    table.ForeignKey(
                        name: "FK_WorkoutLinks_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WorkoutImages",
                columns: new[] { "WorkoutImageId", "ImageUrl", "WorkoutId" },
                values: new object[,]
                {
                    { 1, "/images/hiit1_1.jpg", 1 },
                    { 2, "/images/hiit1_2.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutLinks",
                columns: new[] { "WorkoutLinkId", "Url", "WorkoutId" },
                values: new object[,]
                {
                    { 1, "https://example.com/power-yoga-flow-video", 2 },
                    { 2, "https://www.youtube.com/watch?v=Av7yZ_2yl2A", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1,
                column: "Description",
                value: "Experience a dynamic, heart-pounding workout designed to maximize fat burn and boost your metabolism. Short, intense bursts of exercise followed by brief rest periods will push your limits and leave you feeling energized.");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2,
                column: "Description",
                value: "Immerse yourself in the fluid movements of power yoga. This program combines strength, flexibility, and mindfulness, offering a holistic approach to fitness. ");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Embrace the intensity of CrossFit with a diverse circuit that targets all aspects of fitness", "3 weeks" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutImages_WorkoutId",
                table: "WorkoutImages",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLinks_WorkoutId",
                table: "WorkoutLinks",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutImages");

            migrationBuilder.DropTable(
                name: "WorkoutLinks");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1,
                column: "Description",
                value: " Experience a dynamic, heart-pounding workout designed to maximize fat burn and boost your metabolism. Short, intense bursts of exercise followed by brief rest periods will push your limits and leave you feeling energized.");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2,
                column: "Description",
                value: " Immerse yourself in the fluid movements of power yoga. This program combines strength, flexibility, and mindfulness, offering a holistic approach to fitness. ");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3,
                columns: new[] { "Description", "Duration" },
                values: new object[] { " Embrace the intensity of CrossFit with a diverse circuit that targets all aspects of fitness", "3 weeks " });
        }
    }
}
