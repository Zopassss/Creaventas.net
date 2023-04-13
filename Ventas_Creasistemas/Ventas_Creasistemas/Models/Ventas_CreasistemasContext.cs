using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ventas_Creasistemas.Models
{
    public partial class Ventas_CreasistemasContext : DbContext
    {
        public Ventas_CreasistemasContext()
        {
        }

        public Ventas_CreasistemasContext(DbContextOptions<Ventas_CreasistemasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JCASTROC\\SQLEXPRESS; Database=Ventas_Creasistemas; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("pk_Prodcuto");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_Producto")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.Producto)
                    .HasPrincipalKey<Ventas>(p => p.IdProducto)
                    .HasForeignKey<Producto>(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Producto");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("pk_Usuario");

                entity.Property(e => e.IdUsuarios)
                    .HasColumnName("id_Usuarios")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuariosNavigation)
                    .WithOne(p => p.Usuarios)
                    .HasPrincipalKey<Ventas>(p => p.IdUsuarios)
                    .HasForeignKey<Usuarios>(d => d.IdUsuarios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Usuarios");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.IdVentas)
                    .HasName("pk_VentasProducto");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("UQ__Ventas__DB05CEDAB9461860")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuarios)
                    .HasName("UQ__Ventas__F80D2BD6266E2C44")
                    .IsUnique();

                entity.Property(e => e.IdVentas)
                    .HasColumnName("id_Ventas")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IdProducto).HasColumnName("id_Producto");

                entity.Property(e => e.IdUsuarios).HasColumnName("id_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
