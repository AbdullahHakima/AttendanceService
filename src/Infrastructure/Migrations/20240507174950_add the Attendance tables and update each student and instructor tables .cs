using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtheAttendancetablesandupdateeachstudentandinstructortables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Radius = table.Column<double>(type: "double precision", nullable: true),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceSession_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceSession_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceSession_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "AttendanceRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AttendanceSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubmissionTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentLatitude = table.Column<double>(type: "double precision", nullable: false),
                    StudentLongitude = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Justification = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceRecord_AttendanceSession_AttendanceSessionId",
                        column: x => x.AttendanceSessionId,
                        principalTable: "AttendanceSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceRecord_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecord_AttendanceSessionId",
                table: "AttendanceRecord",
                column: "AttendanceSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecord_StudentId",
                table: "AttendanceRecord",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSession_CourseId",
                table: "AttendanceSession",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSession_InstructorId",
                table: "AttendanceSession",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSession_LocationId",
                table: "AttendanceSession",
                column: "LocationId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceRecord");

            migrationBuilder.DropTable(
                name: "InstructorCourses");

            migrationBuilder.DropTable(
                name: "ModuleQuestion");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentQuizzes");

            migrationBuilder.DropTable(
                name: "AttendanceSession");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Quizs");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
