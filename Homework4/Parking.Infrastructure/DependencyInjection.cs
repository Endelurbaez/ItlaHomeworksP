using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Repositories;

namespace Parking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            // DbContext
            services.AddDbContext<ParkingDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<ITarifaRepository, TarifaRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
