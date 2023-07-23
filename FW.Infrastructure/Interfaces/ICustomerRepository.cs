using FW.Domain.Entities;
using FW.Domain.ValueObject.StrongTypeId;

namespace FW.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(CustomerId id);
}
