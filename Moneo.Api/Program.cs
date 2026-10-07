using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Moneo.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("MoneoDb")
    ?? throw new InvalidOperationException("La chaîne de connexion 'MoneoDb' est introuvable.");

builder.Services.AddDbContext<MoneoDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
