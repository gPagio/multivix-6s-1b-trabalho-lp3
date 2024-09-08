using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class Voos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "voos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_origem = table.Column<long>(type: "bigint", nullable: false),
                    id_destino = table.Column<long>(type: "bigint", nullable: false),
                    data_ida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_volta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_companhia_operante = table.Column<long>(type: "bigint", nullable: false),
                    preco = table.Column<double>(type: "double precision", nullable: false),
                    quantiade_assentos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voos");
        }
    }
}
