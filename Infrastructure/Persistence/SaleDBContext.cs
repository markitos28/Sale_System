using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SaleDBContext:DbContext
    {
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\MSSQLSERVER01; Database = staging; User Id = UserLocal; Password = SqlServer01!; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(s => s.CarritoId);
                entity.HasOne<Cliente>(s => s.Cliente)
                .WithMany(s=> s.CarritosId)
                .HasForeignKey(s => s.ClienteId);
                entity.HasMany<CarritoProducto>(s => s.CarritoProductosId)
                .WithOne(s => s.Carrito);
                entity.HasOne<Orden>(s => s.Orden)
                .WithOne(s => s.Carrito);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(s => s.ClienteId)
                .ValueGeneratedOnAdd()
                .IsRequired();
                entity.HasKey(s => s.ClienteId);
                entity.HasMany<Carrito>(s => s.CarritosId)
                .WithOne(s=> s.Cliente);
                entity.Property(s => s.DNI).HasMaxLength(10);
                entity.Property(s => s.Nombre).HasMaxLength(25);
                entity.Property(s => s.Apellido).HasMaxLength(25);
                entity.Property(s => s.Telefono).HasMaxLength(13);

            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.HasKey(s => new { s.CarritoId, s.ProductoId }); 
                entity.HasOne<Carrito>(s => s.Carrito)
                .WithMany(s => s.CarritoProductosId)
                .HasForeignKey(s => s.CarritoId);
                entity.HasOne<Producto>(s => s.Producto)
                .WithMany(s => s.CarritoProductosId)
                .HasForeignKey(s => s.ProductoId); 
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(s => s.OrdenId );
                entity.HasOne<Carrito>(s => s.Carrito).WithOne(s => s.Orden);
                entity.Property(s => s.Total).HasPrecision(15,2);
            });
            
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(s => s.ProductoId).ValueGeneratedOnAdd().IsRequired();
                entity.HasKey(s => s.ProductoId);
                entity.HasMany<CarritoProducto>(s => s.CarritoProductosId).WithOne(s => s.Producto);
                entity.Property(m => m.Marca).HasMaxLength(25);
                entity.Property(m => m.Codigo).HasMaxLength(25);
                entity.Property(m => m.Precio).HasPrecision(15,2);
            });



        }
    }
}
