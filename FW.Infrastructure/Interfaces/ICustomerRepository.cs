﻿using FW.Domain.Entities;

namespace FW.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<int> AddAsync(Customer customer);
    Task<int> DeleteAsync(Customer customer);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<List<Customer>> GetByNameAsync(string name);
    Task<int> UpdateAsync(Customer customer);
}
