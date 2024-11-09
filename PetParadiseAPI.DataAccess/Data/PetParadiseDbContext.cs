using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetParadiseAPI.DataAccess.Data;

public partial class PetParadiseDbContext : DbContext
{
    public PetParadiseDbContext()
    {
    }

    public PetParadiseDbContext(DbContextOptions<PetParadiseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__carrito__83A2AD9C1D2F7BDC");

            entity.ToTable("carrito");

            entity.Property(e => e.IdCarrito)
                .ValueGeneratedNever()
                .HasColumnName("id_carrito");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__carrito__id_prod__4F7CD00D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__carrito__id_usua__5070F446");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D2E928C3E");

            entity.ToTable("producto");

            entity.HasIndex(e => e.IdProducto, "UQ__producto__FF341C0CBDE6CCB8").IsUnique();

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_producto");
            entity.Property(e => e.FotoProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("foto_producto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.PrecioProducto)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("precio_producto");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04AD9FF5D31C");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.IdUsuario, "UQ__usuario__4E3E04AC5F2937D4").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ApellidosUsuario)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidos_usuario");
            entity.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contraseña_usuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo_usuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.TelefonoUsuario)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("telefono_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
