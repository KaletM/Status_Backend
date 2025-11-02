using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusApi.Services.RepositoriesImpl;
using StatusApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25)) // Cambia la versión según tu instalación de MySQL
    ));
    
builder.Services.AddScoped<IRestaurantRepository, RestaurantService>();
builder.Services.AddSwaggerGen();


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