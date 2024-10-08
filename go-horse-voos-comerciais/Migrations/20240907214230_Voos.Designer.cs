﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace go_horse_voos_comerciais.Migrations
{
    [DbContext(typeof(ApiGhvcDbContext))]
    [Migration("20240907214230_Voos")]
    partial class Voos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Clientes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .HasColumnType("text")
                        .HasColumnName("endereco");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("TelefoneCelular")
                        .HasColumnType("text")
                        .HasColumnName("telefoneCelular");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("text")
                        .HasColumnName("telefoneFixo");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("CompanhiasOperantes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("text")
                        .HasColumnName("cnpj");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("CompanhiasOperantes");
                });

            modelBuilder.Entity("Locais", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("locais");
                });

            modelBuilder.Entity("go_horse_voos_comerciais.Domain.Voo.Voo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataIda")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_ida");

                    b.Property<DateTime>("DataVolta")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_volta");

                    b.Property<long>("IdCompanhiaOperante")
                        .HasColumnType("bigint")
                        .HasColumnName("id_companhia_operante");

                    b.Property<long>("IdDestino")
                        .HasColumnType("bigint")
                        .HasColumnName("id_destino");

                    b.Property<long>("IdOrigem")
                        .HasColumnType("bigint")
                        .HasColumnName("id_origem");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision")
                        .HasColumnName("preco");

                    b.Property<int>("QuantidadeAssentos")
                        .HasColumnType("integer")
                        .HasColumnName("quantiade_assentos");

                    b.HasKey("Id");

                    b.ToTable("voos");
                });
#pragma warning restore 612, 618
        }
    }
}
