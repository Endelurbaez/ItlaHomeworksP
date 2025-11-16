using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;

namespace Parking.Infrastructure.Data
{
    public class ParkinDbContext : DbContext
    {
        public ParkinDbContext(DbContextOptions<ParkinDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.HasMany(e => e.Vehiculos)
                      .WithOne(v => v.Cliente)
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Vehiculo
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Placa).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Marca).HasMaxLength(50);
                entity.Property(e => e.Modelo).HasMaxLength(50);
            });

            // Tarifa
            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion).HasMaxLength(100);
                entity.Property(e => e.PrecioHora).HasColumnType("decimal(10,2)");
            });

            // Ticket
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FechaEntrada).IsRequired();
                entity.Property(e => e.FechaSalida);
                entity.Property(e => e.Total).HasColumnType("decimal(10,2)");

                entity.HasOne(t => t.Vehiculo)
                      .WithMany()
                      .HasForeignKey(t => t.VehiculoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Tarifa)
                      .WithMany()
                      .HasForeignKey(t => t.TarifaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}


