namespace FW.Domain.Entities;

public class LineItem
{
    internal LineItem(Guid id, Guid orderId, Guid productId, decimal price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal Price { get; private set; }
}