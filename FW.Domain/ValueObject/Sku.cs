namespace FW.Domain.ValueObject;

public record Sku
{
    private const int DefaultLength = 15;

    private Sku(string value) => Value = value;

    public string Value { get; init; }

    public static Sku? Create(string? value)
    {
        string? trimedValue = value?.Trim();

        if (trimedValue?.Length != DefaultLength)
            return null;

        return new Sku(trimedValue);
    }
}