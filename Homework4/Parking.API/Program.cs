var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// HABILITAR CORS para permitir conexiones del MVC
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMVC",
        policy => policy
            .WithOrigins(
                "https://localhost:7222",  // MVC HTTPS
                "http://localhost:5041",   // MVC HTTP
                "https://localhost:7274",  // API misma (opcional)
                "http://localhost:5262"    // API misma (opcional)
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

// ... resto de servicios (Swagger, etc.)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowMVC");  // ← ¡ESTO ES CRÍTICO!
app.UseAuthorization();
app.MapControllers();

app.Run();