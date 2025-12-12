using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;

namespace Parking.Infrastructure
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
            : base(options)
        {
        }

        // DbSets para cada entidad
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });

            // Configuración de Vehiculo
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Marca).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Modelo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Placa).IsRequired().HasMaxLength(20);

                entity.HasOne(v => v.Cliente)
                      .WithMany(c => c.Vehiculos)
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Tarifa
            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PrecioHora).HasColumnType("decimal(10,2)");
            });

            // Configuración de Ticket
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(t => t.HoraEntrada).IsRequired();
                entity.Property(t => t.HoraSalida);
                entity.Property(t => t.Total).HasColumnType("decimal(10,2)");

                entity.HasOne(t => t.Vehiculo)
                      .WithMany(v => v.Tickets)
                      .HasForeignKey(t => t.VehiculoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.Tarifa)
                      .WithMany(tr => tr.Tickets)
                      .HasForeignKey(t => t.TarifaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
