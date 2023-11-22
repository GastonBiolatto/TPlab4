using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bomberosfinallab.Migrations
{
    /// <inheritdoc />
    public partial class migrationdos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemPelicula",
                table: "CuerpoActivo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemPelicula",
                table: "CuerpoActivo");
        }
    }
}
