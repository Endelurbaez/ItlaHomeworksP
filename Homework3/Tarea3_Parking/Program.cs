using Microsoft.EntityFrameworkCore;
using Parking.Infrastructure.Data;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Repositories;
using Parking.Infrastructure.Core;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ParkingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios (puedes registrar genérico si quieres)
builder.Services.AddScoped(typeof(BaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// ... middleware etc.
app.Run();
