using FW.Domain.StrongTyped;

namespace FW.Domain.Entities;

public class Address
{
    private Address(
        CustomerId customerId,
        string street,
        string number,
        string? complement,
        string neighbourhood,
        string city,
        string state,
        string postalCode,
        string country)
    {
        CustomerId = customerId;
        Street = street;
        Number = number;
        Complement = complement;
        Neighbourhood = neighbourhood;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public AddressId Id { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string? Complement { get; private set; }
    public string Neighbourhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public Customer Customer { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public static Address Create(
        string street,
        string number,
        string? complement,
        string neighbourhood,
        string city,
        string state,
        string postalCode,
        string country,
        CustomerId customerId)
    {
        return new(
            customerId,
            street,
            number,
            complement,
            neighbourhood,
            city,
            state,
            postalCode,
            country);
    }
}
