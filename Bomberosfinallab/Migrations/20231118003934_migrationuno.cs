using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bomberosfinallab.Migrations
{
    /// <inheritdoc />
    public partial class migrationuno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRevicion = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuerpoActivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nro = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartamentoRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuerpoActivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuerpoActivo_Departamento_DepartamentoRefId",
                        column: x => x.DepartamentoRefId,
                        principalTable: "Departamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRevicion = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DepartamentoRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamiento_Departamento_DepartamentoRefId",
                        column: x => x.DepartamentoRefId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContAsistencia = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CuerpoActivoRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistencia_CuerpoActivo_CuerpoActivoRefId",
                        column: x => x.CuerpoActivoRefId,
                        principalTable: "CuerpoActivo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_CuerpoActivoRefId",
                table: "Asistencia",
                column: "CuerpoActivoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_CuerpoActivo_DepartamentoRefId",
                table: "CuerpoActivo",
                column: "DepartamentoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamiento_DepartamentoRefId",
                table: "Equipamiento",
                column: "DepartamentoRefId");
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
