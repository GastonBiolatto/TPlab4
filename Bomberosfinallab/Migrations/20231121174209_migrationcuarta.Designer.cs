﻿// <auto-generated />
using System;
using Bomberosfinallab.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bomberosfinallab.Migrations
{
    [DbContext(typeof(BomberosContext))]
    [Migration("20231121174209_migrationcuarta")]
    partial class migrationcuarta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bomberosfinallab.Models.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContAsistencia")
                        .HasColumnType("int");

                    b.Property<int?>("CuerpoActivoRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CuerpoActivoRefId");

                    b.ToTable("Asistencia");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.CuerpoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentoRefId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Nro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoRefId");

                    b.ToTable("CuerpoActivo");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.Equipamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("DepartamentoRefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRevicion")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoRefId");

                    b.ToTable("Equipamiento");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.Unidades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaRevicion")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.Asistencia", b =>
                {
                    b.HasOne("Bomberosfinallab.Models.CuerpoActivo", "CuerpoActivo")
                        .WithMany()
                        .HasForeignKey("CuerpoActivoRefId");

                    b.Navigation("CuerpoActivo");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.CuerpoActivo", b =>
                {
                    b.HasOne("Bomberosfinallab.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoRefId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Bomberosfinallab.Models.Equipamiento", b =>
                {
                    b.HasOne("Bomberosfinallab.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });
#pragma warning restore 612, 618
        }
    }
}
