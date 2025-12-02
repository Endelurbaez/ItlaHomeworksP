using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;

namespace ParkingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}

