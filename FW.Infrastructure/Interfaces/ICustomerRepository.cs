using FW.Domain.Entities;
using FW.Domain.StrongTyped;

namespace FW.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<int> AddAsync(Customer customer);
    Task<int> DeleteAsync(Customer customer);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task<List<Customer>> GetByNameAsync(string name);
    Task<int> UpdateAsync(Customer customer);
}
