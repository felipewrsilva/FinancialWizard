using FW.Domain.ValueObject;

namespace FW.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public Sku Sku { get; set; } = null!;
}
