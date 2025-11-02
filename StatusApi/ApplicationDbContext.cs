using Microsoft.EntityFrameworkCore;
using StatusApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Restaurant> Restaurants { get; set; }
}