using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusApi.Services.RepositoriesImpl;
using StatusApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StatusApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25)) 
    ));
    
builder.Services.AddScoped<IRestaurantRepository, RestaurantService>();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<ISupplierRepository, SupplierService>();
builder.Services.AddScoped<ISupplierOrderRepository, SupplierOrderService>();
builder.Services.AddScoped<ISupplierOrderDetailRepository, SupplierOrderDetailService>();
builder.Services.AddScoped<IInventoryMovementRepository, InventoryMovementService>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();