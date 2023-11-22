using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPlab4.Migrations
{
    /// <inheritdoc />
    public partial class cincomiuno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duracion",
                table: "CuerpoActivo",
                newName: "DNI");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "CuerpoActivo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DNI",
                table: "CuerpoActivo",
                newName: "Duracion");

            migrationBuilder.AlterColumn<int>(
                name: "Direccion",
                table: "CuerpoActivo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
