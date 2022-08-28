﻿// <auto-generated />
using System;
using LuisCriolloPrueba.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LuisCriolloPrueba.Migrations
{
    [DbContext(typeof(BaseDatosContext))]
    [Migration("20220827125041_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LuisCriolloPrueba.Modelos.Cliente", b =>
                {
                    b.Property<int>("clienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("idPersona")
                        .HasColumnType("int");

                    b.HasKey("clienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LuisCriolloPrueba.Modelos.Cuenta", b =>
                {
                    b.Property<int>("idCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("numeroCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("saldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("tipoCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCuenta");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("LuisCriolloPrueba.Modelos.Movimiento", b =>
                {
                    b.Property<int>("idMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<string>("descripcionCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("fechaMovimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCuenta")
                        .HasColumnType("int");

                    b.Property<decimal>("movimiento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("numeroCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("saldoDisponible")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("saldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idMovimiento");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("LuisCriolloPrueba.Modelos.Persona", b =>
                {
                    b.Property<int>("idPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPersona");

                    b.ToTable("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}
