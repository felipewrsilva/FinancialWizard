using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using FW.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FW.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly FWDbContext _context;

    public CustomerRepository(FWDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(CustomerId id)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Customer>> GetByNameAsync(string name)
    {
        return await _context.Customers
            .Where(c => c.Name == name)
            .ToListAsync();
    }

    public async Task<int> UpdateAsync(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }
}
