using FW.Domain.StrongTyped;
using FW.Domain.ValueObject;

namespace FW.Domain.Entities;

public class Customer
{
    private readonly List<Address> _addresses = new();

    private Customer(CustomerId id, string name, Email? email, Phone? phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public CustomerId Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

    public static Customer Create(CustomerId id, string name, Email email) => new(id, name, email, null);

    public static Customer Create(CustomerId id, string name, Phone phone) => new(id, name, null, phone);

    public static Customer Create(CustomerId id, string name, Email email, Phone phone) => new(id, name, email, phone);
}
