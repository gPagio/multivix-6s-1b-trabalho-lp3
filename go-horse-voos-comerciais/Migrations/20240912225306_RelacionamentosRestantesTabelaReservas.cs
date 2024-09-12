using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentosRestantesTabelaReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_cliente",
                table: "reservas",
                column: "id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_clientes_id_cliente",
                table: "reservas",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservas_clientes_id_cliente",
                table: "reservas");

            migrationBuilder.DropIndex(
                name: "IX_reservas_id_cliente",
                table: "reservas");
        }
    }
}
