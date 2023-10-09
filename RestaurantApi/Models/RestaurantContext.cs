using Microsoft.EntityFrameworkCore;

namespace RestoranApi.Models;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options)
    : base(options)
    { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("stbl_System_Users");
    }
}