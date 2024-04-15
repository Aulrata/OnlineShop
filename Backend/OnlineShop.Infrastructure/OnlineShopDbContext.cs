using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Configurations;
using OnlineShop.Infrastructure.Entities;

namespace OnlineShop.Infrastructure;

public class OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}