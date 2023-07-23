using FW.Domain.ValueObject;
using FW.Domain.ValueObject.StrongTypeId;

namespace FW.Domain.Entities;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    private Order() { }

    public OrderId Id { get; private set; } = null!;

    public CustomerId CustomerId { get; private set; } = null!;

    public IReadOnlyCollection<LineItem> LineItems => _lineItems.ToList();

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customer.Id
        };

        return order;
    }

    public void Add(ProductId productId, decimal productPrice)
    {
        var lineItem = new LineItem(
            id: new LineItemId(Guid.NewGuid()),
            orderId: Id,
            productId,
            productPrice);

        _lineItems.Add(lineItem);
    }
}
