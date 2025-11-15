using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;

namespace Parking.Infrastructure.Data
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }

    }
}
