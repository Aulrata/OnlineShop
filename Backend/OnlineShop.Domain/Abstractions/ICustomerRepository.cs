using OnlineShop.Domain.Models.Customer;

namespace OnlineShop.Domain.Abstractions;

public interface ICustomerRepository
{
    Task Create(CustomerModel model);

    Task<List<CustomerModel>> Get();

    Task<CustomerModel> Update(CustomerModel model);

    Task Delete(CustomerModel model);
}