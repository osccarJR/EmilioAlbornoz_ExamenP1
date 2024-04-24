using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmilioAlbornoz_ExamenP1.Migrations
{
    /// <inheritdoc />
    public partial class CambiosBdd1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pollo",
                columns: table => new
                {
                    EA_PolloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EA_Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EA_Piezas = table.Column<int>(type: "int", nullable: false),
                    EA_FechadeProduccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EA_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EA_IncluyeSalsa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pollo", x => x.EA_PolloId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pollo");
        }
    }
}
