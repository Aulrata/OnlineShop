namespace OnlineShop.API.DTO;

public record CustomersResponse(
    Guid Id,
    string Name,
    string Email);