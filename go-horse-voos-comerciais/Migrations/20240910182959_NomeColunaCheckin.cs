using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class NomeColunaCheckin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "passagens",
                newName: "checkin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checkin",
                table: "passagens",
                newName: "CheckIn");
        }
    }
}
