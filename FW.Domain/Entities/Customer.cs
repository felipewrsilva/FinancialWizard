using FW.Domain.StrongTyped;
using FW.Domain.ValueObject;

namespace FW.Domain.Entities;

public class Customer
{
    private readonly List<Address> _addresses = new();

    private Customer(string name, Email? email, Phone? phone, Guid? id = null)
    {
        if (id != null)
            Id = new CustomerId(id.Value);

        Name = name;
        Email = email;
        Phone = phone;
    }

    public CustomerId Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

    public static Customer Create(string name, Email email) => new(name, email, phone: null);

    public static Customer Create(string name, Phone phone) => new(name, email: null, phone);

    public static Customer Create(string name, Email email, Phone phone) => new(name, email, phone);

    public static Customer Create(Guid id, string name, Email email, Phone phone) => new(name, email, phone, id);
}
