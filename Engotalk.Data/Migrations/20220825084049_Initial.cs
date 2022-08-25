using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engotalk.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

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

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    University = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityId);
                    table.ForeignKey(
                        name: "FK_Universities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityDepartments",
                columns: table => new
                {
                    UniversityDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityDepartments", x => x.UniversityDepartmentId);
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitleId = table.Column<int>(type: "int", nullable: false),
                    UniversityDepartmentId = table.Column<int>(type: "int", nullable: false),
                    universityDepartmentsUniversityDepartmentId = table.Column<int>(type: "int", nullable: false),
                    Band = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseDuration = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_CourseTitles_CourseTitleId",
                        column: x => x.CourseTitleId,
                        principalTable: "CourseTitles",
                        principalColumn: "CourseTitleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_UniversityDepartments_universityDepartmentsUniversityDepartmentId",
                        column: x => x.universityDepartmentsUniversityDepartmentId,
                        principalTable: "UniversityDepartments",
                        principalColumn: "UniversityDepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseTitleId",
                table: "Courses",
                column: "CourseTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_universityDepartmentsUniversityDepartmentId",
                table: "Courses",
                column: "universityDepartmentsUniversityDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CountryId",
                table: "Universities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDepartments_DepartmentId",
                table: "UniversityDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDepartments_UniversityId",
                table: "UniversityDepartments",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseTitles");

            migrationBuilder.DropTable(
                name: "UniversityDepartments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
