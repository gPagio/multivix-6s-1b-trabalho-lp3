using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentosRestantesTabelaVoos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_voos_id_destino",
                table: "voos",
                column: "id_destino");

            migrationBuilder.CreateIndex(
                name: "IX_voos_id_origem",
                table: "voos",
                column: "id_origem");

            migrationBuilder.AddForeignKey(
                name: "FK_voos_locais_id_destino",
                table: "voos",
                column: "id_destino",
                principalTable: "locais",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_voos_locais_id_origem",
                table: "voos",
                column: "id_origem",
                principalTable: "locais",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_voos_locais_id_destino",
                table: "voos");

            migrationBuilder.DropForeignKey(
                name: "FK_voos_locais_id_origem",
                table: "voos");

            migrationBuilder.DropIndex(
                name: "IX_voos_id_destino",
                table: "voos");

            migrationBuilder.DropIndex(
                name: "IX_voos_id_origem",
                table: "voos");
        }
    }
}
