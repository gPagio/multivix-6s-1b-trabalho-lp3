using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentoVooReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_voo",
                table: "reservas",
                column: "id_voo");

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_voos_id_voo",
                table: "reservas",
                column: "id_voo",
                principalTable: "voos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservas_voos_id_voo",
                table: "reservas");

            migrationBuilder.DropIndex(
                name: "IX_reservas_id_voo",
                table: "reservas");
        }
    }
}
