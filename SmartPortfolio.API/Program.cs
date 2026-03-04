using Microsoft.EntityFrameworkCore;
using SmartPortfolio.Application.Abstractions.Repositories;
using SmartPortfolio.Application.Abstractions.Services;
using SmartPortfolio.Persistance.Data;
using SmartPortfolio.Persistance.Implementations.Repositories;
using SmartPortfolio.Persistance.Implementations.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure CORS to allow your frontend to connect
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalFrontend",
        policy =>
        {
            // Replace with your exact frontend URL (e.g., Vite defaults to 5173)
            policy.WithOrigins("http://localhost:5173") 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors("AllowLocalFrontend"); 

app.UseAuthorization();
app.MapControllers();

app.Run();