using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bomberosfinallab.Models;

namespace Bomberosfinallab.Repos;

public partial class BomberosContext : DbContext
{
    public BomberosContext()
    {
    }

    public BomberosContext(DbContextOptions<BomberosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }
    public virtual DbSet<CuerpoActivo> CuerpoActivos { get; set; }
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
