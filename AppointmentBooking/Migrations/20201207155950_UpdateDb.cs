using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentBooking.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PracticeId",
                table: "PatientNote",
                newName: "PractitionerId");

            migrationBuilder.RenameColumn(
                name: "PracticeId",
                table: "Appointment",
                newName: "PractitionerId");

            migrationBuilder.AlterColumn<string>(
                name: "NoteDescription",
                table: "PatientNote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "AppointmentId", "AppointmentDateTime", "PatientId", "PractitionerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 7, 15, 59, 47, 248, DateTimeKind.Local).AddTicks(7905), 1, 1 },
                    { 2, new DateTime(2020, 12, 7, 15, 59, 47, 264, DateTimeKind.Local).AddTicks(3960), 1, 2 },
                    { 3, new DateTime(2020, 12, 7, 15, 59, 47, 264, DateTimeKind.Local).AddTicks(4305), 1, 3 },
                    { 4, new DateTime(2020, 12, 7, 15, 59, 47, 264, DateTimeKind.Local).AddTicks(4495), 2, 2 },
                    { 5, new DateTime(2020, 12, 7, 15, 59, 47, 264, DateTimeKind.Local).AddTicks(4597), 2, 2 },
                    { 6, new DateTime(2020, 12, 7, 15, 59, 47, 264, DateTimeKind.Local).AddTicks(4709), 4, 3 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "UserName",
                value: "reception");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "UserName",
                value: "practitioner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "PractitionerId",
                table: "PatientNote",
                newName: "PracticeId");

            migrationBuilder.RenameColumn(
                name: "PractitionerId",
                table: "Appointment",
                newName: "PracticeId");

            migrationBuilder.AlterColumn<string>(
                name: "NoteDescription",
                table: "PatientNote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserName",
                value: "username1");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "UserName",
                value: "username2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "UserName",
                value: "username3");
        }
    }
}
