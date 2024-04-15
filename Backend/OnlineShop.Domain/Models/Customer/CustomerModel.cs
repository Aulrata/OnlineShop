namespace OnlineShop.Domain.Models.Customer;

public class CustomerModel
{
    public CustomerModel(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public Guid Id { get; init; }

    public string Name { get; private set; }
    
    public string Email { get; private set; }
}