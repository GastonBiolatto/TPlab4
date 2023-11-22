using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPlab4.Migrations
{
    /// <inheritdoc />
    public partial class intentocincomil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    IDUnidades = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRevicion = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.IDUnidades);
                });

            migrationBuilder.CreateTable(
                name: "CuerpoActivo",
                columns: table => new
                {
                    IDCuerpoActivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<int>(type: "int", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuerpoActivo", x => x.IDCuerpoActivo);
                    table.ForeignKey(
                        name: "FK_CuerpoActivo_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamiento",
                columns: table => new
                {
                    IDEquipamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRevicion = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamiento", x => x.IDEquipamiento);
                    table.ForeignKey(
                        name: "FK_Equipamiento_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    IDAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContAsistencia = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IDCuerpoActivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.IDAsistencia);
                    table.ForeignKey(
                        name: "FK_Asistencia_CuerpoActivo_IDCuerpoActivo",
                        column: x => x.IDCuerpoActivo,
                        principalTable: "CuerpoActivo",
                        principalColumn: "IDCuerpoActivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_IDCuerpoActivo",
                table: "Asistencia",
                column: "IDCuerpoActivo");

            migrationBuilder.CreateIndex(
                name: "IX_CuerpoActivo_IdDepartamento",
                table: "CuerpoActivo",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamiento_IdDepartamento",
                table: "Equipamiento",
                column: "IdDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Equipamiento");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "CuerpoActivo");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
