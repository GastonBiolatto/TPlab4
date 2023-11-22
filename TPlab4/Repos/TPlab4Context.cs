using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tpfinal.Models;

namespace TPlab4.Repos;

public partial class TPlab4Context : DbContext
{
    public TPlab4Context()
    {
    }

    public TPlab4Context(DbContextOptions<TPlab4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }
    public virtual DbSet<CuerpoActivo> CuerpoActivo { get; set; }
    public virtual DbSet<Departamento> Departamentos { get; set; }
    public virtual DbSet<Equipamiento> Equipamientos { get; set; }
    public virtual DbSet<Unidades> Unidades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
