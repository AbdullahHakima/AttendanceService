using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAttendanceSessionwhichaddEndAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "AttendanceSessions",
                newName: "StartAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "AttendanceSessions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "AttendanceSessions");

            migrationBuilder.RenameColumn(
                name: "StartAt",
                table: "AttendanceSessions",
                newName: "Date");
        }
    }
}
