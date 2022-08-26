using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engotalk.Data.Migrations
{
    public partial class nullvalueupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UniversityDepartments_universityDepartmentsUniversityDepartmentId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "universityDepartmentsUniversityDepartmentId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UniversityDepartments_universityDepartmentsUniversityDepartmentId",
                table: "Courses",
                column: "universityDepartmentsUniversityDepartmentId",
                principalTable: "UniversityDepartments",
                principalColumn: "UniversityDepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UniversityDepartments_universityDepartmentsUniversityDepartmentId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "universityDepartmentsUniversityDepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UniversityDepartments_universityDepartmentsUniversityDepartmentId",
                table: "Courses",
                column: "universityDepartmentsUniversityDepartmentId",
                principalTable: "UniversityDepartments",
                principalColumn: "UniversityDepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
