using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoNomeCamposDeEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "reservas",
                newName: "status_reserva");

            migrationBuilder.RenameColumn(
                name: "checkin",
                table: "passagens",
                newName: "situacao_checkin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_reserva",
                table: "reservas",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "situacao_checkin",
                table: "passagens",
                newName: "checkin");
        }
    }
}
