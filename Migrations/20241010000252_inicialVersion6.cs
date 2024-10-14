using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlaggGaming.Migrations
{
    /// <inheritdoc />
    public partial class inicialVersion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "idOferta",
                table: "juegos",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Juego",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Juego");

            migrationBuilder.AlterColumn<Guid>(
                name: "idOferta",
                table: "juegos",
                type: "uniqueidentifier",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
