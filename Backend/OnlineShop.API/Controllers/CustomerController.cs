using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.DTO;
using OnlineShop.Domain.Contracts;
using OnlineShop.Domain.Models.Customer;

namespace OnlineShop.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomersResponse>>> GetCustomers()
    {
        IEnumerable<CustomersResponse> response = new List<CustomersResponse>();
        try
        {
            var customers = await _customerService.GetAllCustomers();
            
            response = customers
                .Select(c => new CustomersResponse(c.Id, c.Name, c.Email));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
        }
         
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCustomer([FromBody] CustomerRequest request)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email))
            return BadRequest($"{nameof(request.Name)} or {nameof(request.Email)} can't be null or empty.");
        
        var customer = new CustomerModel(Guid.NewGuid(), request.Name, request.Email);
        
        try
        {
            await _customerService.CreateCustomer(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
        }
        

        return Ok(customer);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateCustomer(Guid id, [FromBody] CustomerRequest request)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email))
            return BadRequest($"{nameof(request.Name)} or {nameof(request.Email)} can't be null or empty.");
        
        var customer = new CustomerModel(id, request.Name, request.Email);

        await _customerService.UpdateCustomer(customer);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCustomer(Guid id)
    {
        await _customerService.DeleteCustomer(id);
        
        return Ok();
    }
}