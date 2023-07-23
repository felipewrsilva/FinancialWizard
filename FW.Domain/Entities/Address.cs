namespace FW.Domain.Entities;

public class Address
{
    private Address(
        string street,
        string number,
        string? complement,
        string neighbourhood,
        string city,
        string state,
        string postalCode,
        string country)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighbourhood = neighbourhood;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string? Complement { get; private set; }
    public string Neighbourhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

    public static Address Create(
        string street,
        string number,
        string? complement,
        string neighbourhood,
        string city,
        string state,
        string postalCode,
        string country)
    {
        return new(
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
