using Microsoft.EntityFrameworkCore;
using Parking.Application.Interfaces;
using Parking.Application.Services;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Data;
using Parking.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ======= DbContext =======
builder.Services.AddDbContext<ParkinDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ======= Repositories =======
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// ======= Services =======
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<ITarifaService, TarifaService>();
builder.Services.AddScoped<ITicketService, TicketService>();

// ======= Controllers =======
builder.Services.AddControllers();

// ======= Swagger / OpenAPI =======
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

