using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ?? "otracadena";

builder.Services.AddControllers();

// Configuración para usar MySQL
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySql(cadena, new MySqlServerVersion(new Version(8, 0, 32)))); // Cambia la versión si es diferente

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