using FW.Application.Interfaces;
using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using FW.Infrastructure.Interfaces;

namespace FW.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> AddAsync(Customer customer)
    {
        return await _customerRepository.AddAsync(customer);
    }

    public async Task<int> DeleteAsync(CustomerId id)
    {
        const int CustomerNotDeleted = 0;

        Customer? customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
            return CustomerNotDeleted;

        return await DeleteAsync(customer);
    }

    public async Task<int> DeleteAsync(Customer customer)
    {
        return await _customerRepository.DeleteAsync(customer);
    }

    public Task<Customer?> GetByIdAsync(CustomerId id)
    {
        return _customerRepository.GetByIdAsync(id);
    }

    public async Task<int> UpdateAsync(Customer customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }
}
