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

    public static Customer Create(string name, Email email) => new(new CustomerId(Guid.NewGuid()), name, email, phone: null);

    public static Customer Create(string name, Phone phone) => new(new CustomerId(Guid.NewGuid()), name, email: null, phone);
        
    public static Customer Create(string name, Email email, Phone phone) => new(new CustomerId(Guid.NewGuid()), name, email, phone);

    public static Customer Create(CustomerId id, string name, Email email, Phone phone) => new(id, name, email, phone);

    public CustomerId Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
}
