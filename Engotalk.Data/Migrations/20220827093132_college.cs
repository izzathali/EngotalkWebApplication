using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engotalk.Data.Migrations
{
    public partial class college : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "University",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AddColumn<string>(
                name: "UniversityType",
                table: "Universities",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IELTSRequirment",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ListeningBand",
                table: "Courses",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReadingBand",
                table: "Courses",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpeakingBand",
                table: "Courses",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WritingBand",
                table: "Courses",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityType",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "IELTSRequirment",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ListeningBand",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ReadingBand",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SpeakingBand",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "WritingBand",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "University",
                table: "Universities",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
