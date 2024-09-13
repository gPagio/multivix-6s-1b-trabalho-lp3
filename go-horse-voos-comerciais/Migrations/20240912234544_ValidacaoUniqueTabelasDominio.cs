using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class ValidacaoUniqueTabelasDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefoneFixo",
                table: "clientes",
                newName: "telefone_fixo");

            migrationBuilder.RenameColumn(
                name: "telefoneCelular",
                table: "clientes",
                newName: "telefone_celular");

            migrationBuilder.CreateIndex(
                name: "IX_locais_nome",
                table: "locais",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanhiasOperantes_cnpj_nome",
                table: "CompanhiasOperantes",
                columns: new[] { "cnpj", "nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_cpf_nome_email_telefone_celular_telefone_fixo",
                table: "clientes",
                columns: new[] { "cpf", "nome", "email", "telefone_celular", "telefone_fixo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_locais_nome",
                table: "locais");

            migrationBuilder.DropIndex(
                name: "IX_CompanhiasOperantes_cnpj_nome",
                table: "CompanhiasOperantes");

            migrationBuilder.DropIndex(
                name: "IX_clientes_cpf_nome_email_telefone_celular_telefone_fixo",
                table: "clientes");

            migrationBuilder.RenameColumn(
                name: "telefone_fixo",
                table: "clientes",
                newName: "telefoneFixo");

            migrationBuilder.RenameColumn(
                name: "telefone_celular",
                table: "clientes",
                newName: "telefoneCelular");
        }
    }
}
