using Microsoft.EntityFrameworkCore;

namespace RestoranApi.Models;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options)
    : base(options)
    { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRoles> UserRoles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("stbl_System_Users");
        modelBuilder.Entity<Role>().ToTable("stbl_System_Roles");
        modelBuilder.Entity<UserRoles>().ToTable("stbl_System_UserRoles");

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRoles>();
    }
}