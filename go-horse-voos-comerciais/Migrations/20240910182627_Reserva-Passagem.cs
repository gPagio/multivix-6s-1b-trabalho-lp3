using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    /// <inheritdoc />
    public partial class ReservaPassagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_cliente = table.Column<long>(type: "bigint", nullable: false),
                    data_reserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    forma_pagamento = table.Column<int>(type: "integer", nullable: false),
                    id_voo = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passagens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_reserva = table.Column<long>(type: "bigint", nullable: false),
                    numero_assento = table.Column<int>(type: "integer", nullable: false),
                    CheckIn = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_passagens_reservas_id_reserva",
                        column: x => x.id_reserva,
                        principalTable: "reservas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_passagens_id_reserva",
                table: "passagens",
                column: "id_reserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passagens");

            migrationBuilder.DropTable(
                name: "reservas");
        }
    }
}
