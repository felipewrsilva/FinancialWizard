using FW.Domain.StrongTyped;
using FW.Domain.ValueObject;

namespace FW.Domain.Entities;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    private Order() { }

    public Guid Id { get; private set; }

    public CustomerId CustomerId { get; private set; } = null!;

    public IReadOnlyCollection<LineItem> LineItems => _lineItems.ToList();

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id
        };

        return order;
    }

    public void Add(Guid productId, decimal productPrice)
    {
        var lineItem = new LineItem(
            id: Guid.NewGuid(),
            orderId: Id,
            productId,
            productPrice);

        _lineItems.Add(lineItem);
    }
}
