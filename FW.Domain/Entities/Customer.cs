using FW.Domain.StrongTyped;
using FW.Domain.ValueObject;

namespace FW.Domain.Entities;

public class Customer
{
    private Customer(CustomerId id, string name, Email? email, Phone? phone, Address? address)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public CustomerId Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public Address? Address { get; private set; }

    public static Customer Create(CustomerId id, string name, Email email) => new(id, name, email, null, null);

    public static Customer Create(CustomerId id, string name, Phone phone) => new(id, name, null, phone, null);

    public static Customer Create(CustomerId id, string name, Email email, Phone phone) => new(id, name, email, phone, null);

    public static Customer Create(CustomerId id, string name, Address address) => new(id, name, null, null, address);

    public static Customer Create(CustomerId id, string name, Email email, Phone phone, Address address) => new(id, name, email, phone, address);

}
