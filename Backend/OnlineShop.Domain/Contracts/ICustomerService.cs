using OnlineShop.Domain.Models.Customer;

namespace OnlineShop.Domain.Contracts;

public interface ICustomerService
{
    Task CreateCustomer(CustomerModel model);

    Task<List<CustomerModel>> GetAllCustomers();

    Task<CustomerModel> UpdateCustomer(CustomerModel model);

    Task DeleteCustomer(CustomerModel model);
}