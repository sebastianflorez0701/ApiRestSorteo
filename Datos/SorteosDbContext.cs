using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos;

public partial class SorteosDbContext : DbContext
{
    public SorteosDbContext()
    {
    }

    public SorteosDbContext(DbContextOptions<SorteosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<NumerosAsignado> NumerosAsignados { get; set; }

    public virtual DbSet<NumerosDisponiblesCliente> NumerosDisponiblesClientes { get; set; }

    public virtual DbSet<Sorteo> Sorteos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioSorteo> UsuarioSorteos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    
        base.OnConfiguring(optionsBuilder);
    }
#warning 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__885457EED2BAC57E");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .HasColumnName("nombreCliente");
        });

        modelBuilder.Entity<NumerosAsignado>(entity =>
        {
            entity.HasKey(e => e.IdNumeroAsignado).HasName("PK__NumerosA__D0CE05B283039F3B");

            entity.HasIndex(e => new { e.IdUsuario, e.IdCliente, e.IdSorteo, e.NumeroAsignado }, "UQ_NumerosAsignados_Usuario_Cliente_Sorteo_Numero").IsUnique();

            entity.Property(e => e.IdNumeroAsignado).HasColumnName("idNumeroAsignado");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdSorteo).HasColumnName("idSorteo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NumeroAsignado).HasColumnName("numeroAsignado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.NumerosAsignados)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NumerosAs__idCli__5441852A");

            entity.HasOne(d => d.IdSorteoNavigation).WithMany(p => p.NumerosAsignados)
                .HasForeignKey(d => d.IdSorteo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NumerosAs__idSor__5535A963");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.NumerosAsignados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NumerosAs__idUsu__534D60F1");
        });

        modelBuilder.Entity<NumerosDisponiblesCliente>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDisponible).HasName("PK__NumerosD__5724E3C0F8097D77");

            entity.HasIndex(e => new { e.IdCliente, e.Numero }, "UQ_NumeroDisponible_Cliente_Numero").IsUnique();

            entity.Property(e => e.IdNumeroDisponible).HasColumnName("idNumeroDisponible");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Numero).HasColumnName("numero");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.NumerosDisponiblesClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NumerosDi__idCli__4316F928");
        });

        modelBuilder.Entity<Sorteo>(entity =>
        {
            entity.HasKey(e => e.IdSorteo).HasName("PK__Sorteos__85286E60801632F6");

            entity.Property(e => e.IdSorteo).HasColumnName("idSorteo");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.NombreSorteo)
                .HasMaxLength(100)
                .HasColumnName("nombreSorteo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A6E14FA78A");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .HasColumnName("nombreUsuario");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__idClie__46E78A0C");
        });

        modelBuilder.Entity<UsuarioSorteo>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioSorteo).HasName("PK__usuario___B25538065D4EC487");

            entity.ToTable("usuario_sorteo");

            entity.Property(e => e.IdUsuarioSorteo).HasColumnName("idUsuarioSorteo");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.IdSorteo).HasColumnName("idSorteo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdSorteoNavigation).WithMany(p => p.UsuarioSorteos)
                .HasForeignKey(d => d.IdSorteo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario_s__idSor__4D94879B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioSorteos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario_s__idUsu__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
