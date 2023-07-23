namespace FW.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
}
