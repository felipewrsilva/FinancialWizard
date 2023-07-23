using FW.Domain.Entities;
using FW.Domain.ValueObject.StrongTypeId;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FW.Infrastructure.Configurations;

public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(li => li.Id);

        builder.Property(li => li.Id).HasConversion(
            lineItemId => lineItemId.Value,
            value => new LineItemId(value));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(li => li.ProductId);
    }
}
