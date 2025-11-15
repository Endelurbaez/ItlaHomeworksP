using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Parking.Infrastructure.Data
{
    public class ParkingDbContextFactory : IDesignTimeDbContextFactory<ParkingDbContext>
    {
        public ParkingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ParkingDbContext>();

            // ⚠️ PON AQUÍ TU CADENA DE CONEXIÓN
            var connectionString = "Server=.;Database=ParkingDB;Trusted_Connection=True;TrustServerCertificate=True;";

            builder.UseSqlServer(connectionString);

            return new ParkingDbContext(builder.Options);
        }
    }
}

