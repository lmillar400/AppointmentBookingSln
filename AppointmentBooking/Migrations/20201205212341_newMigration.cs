using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentBooking.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PracticeName",
                table: "Practice",
                newName: "PractitionerName");

            migrationBuilder.RenameColumn(
                name: "PracticeId",
                table: "Practice",
                newName: "PractitionerId");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PractitionerId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "PractitionerName",
                table: "Practice",
                newName: "PracticeName");

            migrationBuilder.RenameColumn(
                name: "PractitionerId",
                table: "Practice",
                newName: "PracticeId");
        }
    }
}
