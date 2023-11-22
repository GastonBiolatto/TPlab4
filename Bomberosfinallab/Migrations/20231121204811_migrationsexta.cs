using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bomberosfinallab.Migrations
{
    /// <inheritdoc />
    public partial class migrationsexta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "CuerpoActivo");

            migrationBuilder.AddColumn<string>(
                name: "ImagemBomber",
                table: "CuerpoActivo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemBomber",
                table: "CuerpoActivo");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "CuerpoActivo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
