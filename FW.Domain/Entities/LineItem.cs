using FW.Domain.ValueObject;
using FW.Domain.ValueObject.StrongTypeId;

namespace FW.Domain.Entities;

public class LineItem
{
    internal LineItem(LineItemId id, OrderId orderId, ProductId productId, decimal price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    public LineItemId Id { get; private set; }
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public decimal Price { get; private set; }
}