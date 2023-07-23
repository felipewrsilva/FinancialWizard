using FW.Domain.StrongTyped;

namespace FW.Domain.Entities;

public class Customer
{
    public CustomerId Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
}
