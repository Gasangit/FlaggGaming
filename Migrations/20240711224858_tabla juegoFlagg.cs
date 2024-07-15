using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlaggGaming.Migrations
{
    /// <inheritdoc />
    public partial class tablajuegoFlagg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fechasDeLanzamiento",
                columns: table => new
                {
                    idFecha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proximamente = table.Column<bool>(type: "BIT", nullable: false),
                    fecha = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fechasDeLanzamiento", x => x.idFecha);
                });

            migrationBuilder.CreateTable(
                name: "ofertas",
                columns: table => new
                {
                    idOferta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idFlagg = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    discount_percent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ofertas", x => x.idOferta);
                });

            migrationBuilder.CreateTable(
                name: "juegos",
                columns: table => new
                {
                    idFlagg = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idJuegoTienda = table.Column<string>(type: "varchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "varchar(max)", nullable: true),
                    descripcionCorta = table.Column<string>(type: "varchar(max)", nullable: true),
                    tienda = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagenMini = table.Column<string>(type: "varchar(max)", nullable: true),
                    urlTienda = table.Column<string>(type: "varchar(max)", nullable: true),
                    precio = table.Column<string>(type: "varchar(max)", nullable: true),
                    contadorVistas = table.Column<string>(type: "varchar(max)", nullable: true),
                    idOferta = table.Column<string>(type: "varchar(max)", nullable: true),
                    estudio = table.Column<string>(type: "varchar(max)", nullable: true),
                    requisitos = table.Column<string>(type: "varchar(max)", nullable: true),
                    ofertaidOferta = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fechaLanzamientoidFecha = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_juegos", x => x.idFlagg);
                    table.ForeignKey(
                        name: "FK_juegos_fechasDeLanzamiento_fechaLanzamientoidFecha",
                        column: x => x.fechaLanzamientoidFecha,
                        principalTable: "fechasDeLanzamiento",
                        principalColumn: "idFecha");
                    table.ForeignKey(
                        name: "FK_juegos_ofertas_ofertaidOferta",
                        column: x => x.ofertaidOferta,
                        principalTable: "ofertas",
                        principalColumn: "idOferta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_juegos_fechaLanzamientoidFecha",
                table: "juegos",
                column: "fechaLanzamientoidFecha");

            migrationBuilder.CreateIndex(
                name: "IX_juegos_ofertaidOferta",
                table: "juegos",
                column: "ofertaidOferta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "juegos");

            migrationBuilder.DropTable(
                name: "fechasDeLanzamiento");

            migrationBuilder.DropTable(
                name: "ofertas");
        }
    }
}
