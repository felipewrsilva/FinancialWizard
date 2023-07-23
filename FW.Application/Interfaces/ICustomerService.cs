using FW.Domain.Entities;

namespace FW.Application.Interfaces;

public interface ICustomerService
{
    Task<int> AddAsync(Customer customer);
    Task<int> DeleteAsync(Guid id);
    Task<int> DeleteAsync(Customer customer);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<int> UpdateAsync(Customer customer);
}
