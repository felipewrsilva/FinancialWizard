using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using Microsoft.EntityFrameworkCore;

namespace FW.Infrastructure;

public class FWDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public FWDbContext(DbContextOptions<FWDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasConversion(
                customerId => customerId.Value,
                value => new CustomerId(value));
            entity.Property(c => c.Name).HasMaxLength(255);
            entity.Property(c => c.Email).HasMaxLength(255);
            entity.HasIndex(c => c.Email).IsUnique();
        });
    }
}
