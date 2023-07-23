using FW.Domain.Entities;
using FW.Domain.ValueObject.StrongTypeId;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FW.Infrastructure.Configurations
{
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(li => li.Id);

            builder.Property(li => li.Id).HasConversion(
                lineItemId => lineItemId.Value,
                value => new LineItemId(value));

            builder.Property(li => li.Price)
                   .HasColumnType("decimal(18, 2)");

            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(li => li.ProductId);
        }
    }
}
