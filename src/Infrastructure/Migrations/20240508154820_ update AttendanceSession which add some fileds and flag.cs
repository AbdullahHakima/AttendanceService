using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAttendanceSessionwhichaddsomefiledsandflag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDynamic",
                table: "AttendanceSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "AttendanceSessions",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "AttendanceSessions",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDynamic",
                table: "AttendanceSessions");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AttendanceSessions");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AttendanceSessions");
        }
    }
}
