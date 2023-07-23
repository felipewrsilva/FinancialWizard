using FW.Domain.ValueObject.StrongTypeId;

namespace FW.Domain.Entities;

public class User
{
    public UserId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
}
