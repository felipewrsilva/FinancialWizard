using FW.Domain.ValueObject;
using FW.Domain.ValueObject.StrongTypeId;

namespace FW.Domain.Entities;

public class Product
{
    public ProductId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public Sku Sku { get; set; } = null!;
}
