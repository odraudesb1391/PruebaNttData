using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuisCriolloPrueba.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(nullable: false),
                    contrasena = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    idCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroCuenta = table.Column<string>(nullable: true),
                    tipoCuenta = table.Column<string>(nullable: true),
                    saldoInicial = table.Column<decimal>(nullable: false),
                    estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.idCuenta);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    idMovimiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(nullable: false),
                    idCuenta = table.Column<int>(nullable: false),
                    fechaMovimiento = table.Column<DateTime>(nullable: false),
                    descripcionCliente = table.Column<string>(nullable: true),
                    numeroCuenta = table.Column<string>(nullable: true),
                    saldoInicial = table.Column<decimal>(nullable: false),
                    estado = table.Column<string>(nullable: false),
                    movimiento = table.Column<decimal>(nullable: false),
                    saldoDisponible = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.idMovimiento);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    genero = table.Column<string>(nullable: false),
                    edad = table.Column<int>(nullable: false),
                    identificacion = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idPersona);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
