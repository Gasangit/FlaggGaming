using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlaggGaming.Migrations
{
    /// <inheritdoc />
    public partial class inicialVersion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_juegos_fechasDeLanzamiento_fechaLanzamientoidFecha",
                table: "juegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_juegos",
                table: "juegos");

            migrationBuilder.DropIndex(
                name: "IX_juegos_fechaLanzamientoidFecha",
                table: "juegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemListaJuegoSteam",
                table: "ItemListaJuegoSteam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fechasDeLanzamiento",
                table: "fechasDeLanzamiento");

            migrationBuilder.DropColumn(
                name: "idFlagg",
                table: "ofertas");

            migrationBuilder.DropColumn(
                name: "fechaLanzamientoidFecha",
                table: "juegos");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "juegos");

            migrationBuilder.DropColumn(
                name: "fecha",
                table: "fechasDeLanzamiento");

            migrationBuilder.DropColumn(
                name: "proximamente",
                table: "fechasDeLanzamiento");

            migrationBuilder.RenameTable(
                name: "ItemListaJuegoSteam",
                newName: "listaJuegos");

            migrationBuilder.RenameTable(
                name: "fechasDeLanzamiento",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "idFecha",
                table: "release_date",
                newName: "idFlagg");

            migrationBuilder.AlterColumn<string>(
                name: "urlTienda",
                table: "juegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tienda",
                table: "juegos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "requisitos",
                table: "juegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "juegos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imagenMini",
                table: "juegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imagen",
                table: "juegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "idOferta",
                table: "juegos",
                type: "uniqueidentifier",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idJuegoTienda",
                table: "juegos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "estudio",
                table: "juegos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcionCorta",
                table: "juegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "contadorVistas",
                table: "juegos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "idFlagg",
                table: "juegos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "urlEpic",
                table: "juegos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "listaJuegos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "listaJuegos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "coming_soon",
                table: "release_date",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "release_date",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK__juegos__E007760D83E62722",
                table: "juegos",
                column: "idFlagg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_listaJuegos",
                table: "listaJuegos",
                column: "appid");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_categoria = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    imagen_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__CD54BC5A900ED068", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "ItemListaJuegoEpic",
                columns: table => new
                {
                    appid = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tiendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    cuit = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    dir = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    hr = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    days = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    tel = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    insta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    premium = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tiendas__3213E83F70A355A0", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    eMail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    rolTienda = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuarios__3213E83F26EBE7FB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_interno_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tienda = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    sku_tienda = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    desc_tienda = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    precio_vta = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__producto__A83A1C380111D261", x => x.id_interno_producto);
                    table.ForeignKey(
                        name: "FK__productos__id_ca__4D94879B",
                        column: x => x.id_categoria,
                        principalTable: "categorias",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "FK__productos__id_ti__4E88ABD4",
                        column: x => x.id_tienda,
                        principalTable: "tiendas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "usuarios_tiendas",
                columns: table => new
                {
                    idU = table.Column<int>(type: "int", nullable: false),
                    idT = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuarios__01951BBA4021FFF4", x => new { x.idU, x.idT });
                    table.ForeignKey(
                        name: "FK__usuarios_ti__idT__5070F446",
                        column: x => x.idT,
                        principalTable: "tiendas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__usuarios_ti__idU__5165187F",
                        column: x => x.idU,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_release_date_idFlagg",
                table: "release_date",
                column: "idFlagg");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_categoria",
                table: "productos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_tienda",
                table: "productos",
                column: "id_tienda");

            migrationBuilder.CreateIndex(
                name: "UQ__tiendas__17BADCA0552EA015",
                table: "tiendas",
                column: "razonSocial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tiendas__2CDD9897AFA3BFAE",
                table: "tiendas",
                column: "cuit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tiendas__7A21290479191779",
                table: "tiendas",
                column: "mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__usuarios__410EDA2FD624E763",
                table: "usuarios",
                column: "eMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_tiendas_idT",
                table: "usuarios_tiendas",
                column: "idT");

            migrationBuilder.AddForeignKey(
                name: "FK_release_date_juegos",
                table: "release_date",
                column: "idFlagg",
                principalTable: "juegos",
                principalColumn: "idFlagg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_release_date_juegos",
                table: "release_date");

            migrationBuilder.DropTable(
                name: "ItemListaJuegoEpic");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "usuarios_tiendas");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "tiendas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK__juegos__E007760D83E62722",
                table: "juegos");

            migrationBuilder.DropIndex(
                name: "IX_release_date_idFlagg",
                table: "release_date");

            migrationBuilder.DropPrimaryKey(
                name: "PK_listaJuegos",
                table: "listaJuegos");

            migrationBuilder.DropColumn(
                name: "urlEpic",
                table: "juegos");

            migrationBuilder.DropColumn(
                name: "coming_soon",
                table: "release_date");

            migrationBuilder.DropColumn(
                name: "date",
                table: "release_date");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "listaJuegos");

            migrationBuilder.RenameTable(
                name: "release_date",
                newName: "fechasDeLanzamiento");

            migrationBuilder.RenameTable(
                name: "listaJuegos",
                newName: "ItemListaJuegoSteam");

            migrationBuilder.RenameColumn(
                name: "idFlagg",
                table: "fechasDeLanzamiento",
                newName: "idFecha");

            migrationBuilder.AddColumn<Guid>(
                name: "idFlagg",
                table: "ofertas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "urlTienda",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tienda",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "requisitos",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imagenMini",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imagen",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idOferta",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idJuegoTienda",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "estudio",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcionCorta",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "contadorVistas",
                table: "juegos",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "idFlagg",
                table: "juegos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<Guid>(
                name: "fechaLanzamientoidFecha",
                table: "juegos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "precio",
                table: "juegos",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fecha",
                table: "fechasDeLanzamiento",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "proximamente",
                table: "fechasDeLanzamiento",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "ItemListaJuegoSteam",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_juegos",
                table: "juegos",
                column: "idFlagg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fechasDeLanzamiento",
                table: "fechasDeLanzamiento",
                column: "idFecha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemListaJuegoSteam",
                table: "ItemListaJuegoSteam",
                column: "appid");

            migrationBuilder.CreateIndex(
                name: "IX_juegos_fechaLanzamientoidFecha",
                table: "juegos",
                column: "fechaLanzamientoidFecha");

            migrationBuilder.AddForeignKey(
                name: "FK_juegos_fechasDeLanzamiento_fechaLanzamientoidFecha",
                table: "juegos",
                column: "fechaLanzamientoidFecha",
                principalTable: "fechasDeLanzamiento",
                principalColumn: "idFecha");
        }
    }
}
