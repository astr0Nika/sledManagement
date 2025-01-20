using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apec4_sledManagement.Library.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "BeginDate",
                table: "Reservations",
                newName: "StartDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Reservations",
                newName: "BeginDate");
        }
    }
}
