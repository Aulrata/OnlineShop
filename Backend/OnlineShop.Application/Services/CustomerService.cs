using OnlineShop.Domain.Abstractions;
using OnlineShop.Domain.Contracts;
using OnlineShop.Domain.Models.Customer;

namespace OnlineShop.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task CreateCustomer(CustomerModel model)
    {
        await _customerRepository.Create(model);
    }

    public async Task<List<CustomerModel>> GetAllCustomers()
    {
        return await _customerRepository.Get();
    }

    public async Task UpdateCustomer(CustomerModel model)
    {
        await _customerRepository.Update(model);
    }

    public async Task DeleteCustomer(Guid id)
    {
        await _customerRepository.Delete(id);
    }
}