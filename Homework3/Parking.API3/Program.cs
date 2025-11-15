using Microsoft.EntityFrameworkCore;
using Parking.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------
// 1️⃣ Configurar servicios
// ----------------------------

// DbContext con SQL Server
builder.Services.AddDbContext<ParkingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controladores
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------------------
// 2️⃣ Construir la app
// ----------------------------
var app = builder.Build();

// ----------------------------
// 3️⃣ Middlewares y Swagger
// ----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking API V1");
        c.RoutePrefix = "swagger"; // Swagger estará en http://localhost:<puerto>/swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear controllers
app.MapControllers();

// ----------------------------
// 4️⃣ Ejecutar la aplicación
// ----------------------------
app.Run();

