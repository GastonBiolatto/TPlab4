using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bomberosfinallab.Migrations
{
    /// <inheritdoc />
    public partial class migrationLaTerceraa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemPelicula",
                table: "CuerpoActivo",
                newName: "Imagen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "CuerpoActivo",
                newName: "ImagemPelicula");
        }
    }
}
