using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engotalk.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTitles_CourseTitleId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseTitles");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseTitleId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseTitleId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseTitleId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseTitles",
                columns: table => new
                {
                    CourseTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitle = table.Column<string>(type: "nvarchar(400)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTitles", x => x.CourseTitleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseTitleId",
                table: "Courses",
                column: "CourseTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTitles_CourseTitleId",
                table: "Courses",
                column: "CourseTitleId",
                principalTable: "CourseTitles",
                principalColumn: "CourseTitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
