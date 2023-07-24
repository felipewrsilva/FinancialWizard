using FW.Domain.Entities;
using FW.Domain.StrongTyped;

namespace FW.Application.Interfaces;

public interface ICustomerService
{
    Task<int> AddAsync(Customer customer);
    Task<int> DeleteAsync(CustomerId id);
    Task<int> DeleteAsync(Customer customer);
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task<int> UpdateAsync(Customer customer);
}
