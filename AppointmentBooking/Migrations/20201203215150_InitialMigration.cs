using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentBooking.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PracticeId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "PatientNote",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PracticeId = table.Column<int>(type: "int", nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNote", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "Practice",
                columns: table => new
                {
                    PracticeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practice", x => x.PracticeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "UserName", "UserRoleId" },
                values: new object[,]
                {
                    { 1, "Joe", false, "Bloggs", "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", "username1", 1 },
                    { 2, "Sarah", false, "Kelly", "kS/hbAdIb2QwTRr2wfqW7jLaochIs09hW5AAEZ6h0Mc=", "1tilkvWD5AfSfK5FsnUk3LOmsM6Rjp2hBfkQnd57BnIdD32mgdpA3VPENMJW2799ij4hw7TZUbiBpcOxXF3XxA==", "username2", 2 },
                    { 3, "Paul", false, "Anderson", "b3vCAn9cRm9rcIA+PPTyBcwi5aY7NFKlSM0Zimx9D/s=", "YHwO5Ti8DoU6BlLenehDE+UdKYlWEeRatUEuOl+xL0CnwQrk/4/G+rtyIsug3heT5Buwi4WRcZoeG5I7x7oX5A==", "username3", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleDescription" },
                values: new object[,]
                {
                    { 1, "Practice Admin Staff" },
                    { 2, "Reception Staff" },
                    { 3, "Medical Parctitioner" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "PatientNote");

            migrationBuilder.DropTable(
                name: "Practice");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
