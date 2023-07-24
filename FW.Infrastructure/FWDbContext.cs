using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using FW.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace FW.Infrastructure;

public class FWDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public FWDbContext(DbContextOptions<FWDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            entity.Property(c => c.Id)
                .HasConversion(
                    customerId => customerId.Value,
                    value => new CustomerId(value));

            entity.Property(c => c.Phone).HasConversion(
                phone => phone!.Value,
                value => new Phone(value));

            entity.Property(c => c.Email).HasConversion(
                email => email!.Value,
                value => new Email(value));

            entity.Property(c => c.Name)
                .HasMaxLength(255);
            entity.Property(c => c.Email)
                .HasMaxLength(255);
            entity.HasIndex(c => c.Email)
                  .IsUnique();

            entity.HasMany(c => c.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).HasConversion(
                addressId => addressId.Value,
                value => new AddressId(value));
            entity.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            entity.Property(a => a.Street)
                .HasMaxLength(255);
            entity.Property(a => a.Number)
                .HasMaxLength(255);
            entity.Property(a => a.Complement)
                .HasMaxLength(255);
            entity.Property(a => a.Neighbourhood)
                .HasMaxLength(255);
            entity.Property(a => a.PostalCode)
                .HasMaxLength(255);
            entity.Property(a => a.City)
                .HasMaxLength(255);
            entity.Property(a => a.State)
                .HasMaxLength(255);
            entity.Property(a => a.Country)
                .HasMaxLength(255);
        });
    }
}
