using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<AppUser> AppUser { get; set; }
    public DbSet<UserAddress> UserAddress { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
