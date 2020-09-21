using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroClientes.Data.Migrations
{
    public partial class Ajuste_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
