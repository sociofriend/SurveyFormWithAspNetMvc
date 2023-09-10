using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyFormProject.Migrations
{
    /// <inheritdoc />
    public partial class SurveyFormDb_Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "GuestResponses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "GuestResponses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_GuestResponses_Email",
                table: "GuestResponses",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestResponses_Phone",
                table: "GuestResponses",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GuestResponses_Email",
                table: "GuestResponses");

            migrationBuilder.DropIndex(
                name: "IX_GuestResponses_Phone",
                table: "GuestResponses");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "GuestResponses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "GuestResponses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
