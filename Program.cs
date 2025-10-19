using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Mapping;
using CinemaProject.Repositories.Implementations;
using CinemaProject.Repositories.Interfaces;
using CinemaProject.Repository.Implementations;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Implementations;
using CinemaProject.Service.Interfaces;
using CinemaProject.Services.Implementations;
using CinemaProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Implementations;
using Repository.Interfaces;
using Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Db Context bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddScoped<UserService>(); // service ekleme örneği

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// builder.Services.AddAutoMapper(typeof(UserProfile)); // User Mapping için
builder.Services.AddAutoMapper(typeof(Program)); // Tüm AutoMapperLarı yükler

builder.Services.AddScoped<IUserRepository, UserRepository>(); // Repository katmanı
builder.Services.AddScoped<IUserService, UserService>(); // Service katmanı

builder.Services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
builder.Services.AddScoped<IShowTimeService, ShowTimeService>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<ISeatService, SeatService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
