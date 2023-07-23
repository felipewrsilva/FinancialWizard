using FW.Domain.ValueObject.StrongTypeId;

namespace FW.Domain.Entities;

public class Customer
{
    public CustomerId Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
}
