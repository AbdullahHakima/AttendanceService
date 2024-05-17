using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecord_AttendanceSession_AttendanceSessionId",
                table: "AttendanceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecord_Students_StudentId",
                table: "AttendanceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSession_Instructors_InstructorId",
                table: "AttendanceSession");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSession_Location_LocationId",
                table: "AttendanceSession");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSession_courses_CourseId",
                table: "AttendanceSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceSession",
                table: "AttendanceSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceRecord",
                table: "AttendanceRecord");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "AttendanceSession",
                newName: "AttendanceSessions");

            migrationBuilder.RenameTable(
                name: "AttendanceRecord",
                newName: "AttendanceRecords");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSession_LocationId",
                table: "AttendanceSessions",
                newName: "IX_AttendanceSessions_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSession_InstructorId",
                table: "AttendanceSessions",
                newName: "IX_AttendanceSessions_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSession_CourseId",
                table: "AttendanceSessions",
                newName: "IX_AttendanceSessions_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecord_StudentId",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecord_AttendanceSessionId",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_AttendanceSessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceSessions",
                table: "AttendanceSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceRecords",
                table: "AttendanceRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_AttendanceSessions_AttendanceSessionId",
                table: "AttendanceRecords",
                column: "AttendanceSessionId",
                principalTable: "AttendanceSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_Students_StudentId",
                table: "AttendanceRecords",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSessions_Instructors_InstructorId",
                table: "AttendanceSessions",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSessions_Locations_LocationId",
                table: "AttendanceSessions",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSessions_courses_CourseId",
                table: "AttendanceSessions",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_AttendanceSessions_AttendanceSessionId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_Students_StudentId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSessions_Instructors_InstructorId",
                table: "AttendanceSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSessions_Locations_LocationId",
                table: "AttendanceSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSessions_courses_CourseId",
                table: "AttendanceSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceSessions",
                table: "AttendanceSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceRecords",
                table: "AttendanceRecords");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "AttendanceSessions",
                newName: "AttendanceSession");

            migrationBuilder.RenameTable(
                name: "AttendanceRecords",
                newName: "AttendanceRecord");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSessions_LocationId",
                table: "AttendanceSession",
                newName: "IX_AttendanceSession_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSessions_InstructorId",
                table: "AttendanceSession",
                newName: "IX_AttendanceSession_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSessions_CourseId",
                table: "AttendanceSession",
                newName: "IX_AttendanceSession_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_StudentId",
                table: "AttendanceRecord",
                newName: "IX_AttendanceRecord_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_AttendanceSessionId",
                table: "AttendanceRecord",
                newName: "IX_AttendanceRecord_AttendanceSessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceSession",
                table: "AttendanceSession",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceRecord",
                table: "AttendanceRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecord_AttendanceSession_AttendanceSessionId",
                table: "AttendanceRecord",
                column: "AttendanceSessionId",
                principalTable: "AttendanceSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecord_Students_StudentId",
                table: "AttendanceRecord",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSession_Instructors_InstructorId",
                table: "AttendanceSession",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSession_Location_LocationId",
                table: "AttendanceSession",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSession_courses_CourseId",
                table: "AttendanceSession",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
