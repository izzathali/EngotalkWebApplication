using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engotalk.Data.Migrations
{
    public partial class correction_univ_and_course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Band",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IELTSRequirment",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ListeningBand",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "WritingBand",
                table: "Courses",
                newName: "TOEFLScore");

            migrationBuilder.RenameColumn(
                name: "SpeakingBand",
                table: "Courses",
                newName: "SATScore");

            migrationBuilder.RenameColumn(
                name: "ReadingBand",
                table: "Courses",
                newName: "GREScore");

            migrationBuilder.AddColumn<string>(
                name: "Established",
                table: "Universities",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamsAccepted",
                table: "Universities",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Universities",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "IELTSBand",
                table: "Courses",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Established",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ExamsAccepted",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "IELTSBand",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TOEFLScore",
                table: "Courses",
                newName: "WritingBand");

            migrationBuilder.RenameColumn(
                name: "SATScore",
                table: "Courses",
                newName: "SpeakingBand");

            migrationBuilder.RenameColumn(
                name: "GREScore",
                table: "Courses",
                newName: "ReadingBand");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Band",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IELTSRequirment",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListeningBand",
                table: "Courses",
                type: "nvarchar(20)",
                nullable: true);
        }
    }
}
