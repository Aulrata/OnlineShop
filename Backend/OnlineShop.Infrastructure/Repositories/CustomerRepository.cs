using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Abstractions;
using OnlineShop.Domain.Models.Customer;
using OnlineShop.Infrastructure.Entities;

namespace OnlineShop.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly OnlineShopDbContext _dbContext;

    public CustomerRepository(OnlineShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Create(CustomerModel model)
    {
        var customerEntity = new CustomerEntity
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
        };

        await _dbContext.Customers.AddAsync(customerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<CustomerModel>> Get()
    {
        var customerEntities = await _dbContext.Customers
            .AsNoTracking()
            .ToListAsync();

        var customers = customerEntities
            .Select(c => new CustomerModel(c.Id, c.Name, c.Email))
            .ToList();

        return customers;
    }

    public async Task Update(CustomerModel model)
    {
        await _dbContext.Customers
            .Where(c => c.Id == model.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Name, c => model.Name)
                .SetProperty(c => c.Email, c => model.Email));
    }

    public async Task Delete(CustomerModel model)
    {
        await _dbContext.Customers
            .Where(c => c.Id == model.Id)
            .ExecuteDeleteAsync();
    }
}