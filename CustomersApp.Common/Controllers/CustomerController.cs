using Microsoft.AspNetCore.Mvc;
using CustomersApp.Common.Models;
using CustomersApp.Common.Services;

[Route("api/customer")]
[ApiController]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerService;

    public CustomerController(ICustomerRepository customerService)
    {
        _customerService= customerService;
    }
    
    [HttpPost]
     public async Task<ActionResult> CreateCustomerAsync([FromBody] CustomerDto dto)
    {
        var id = await _customerService.CreateCustomerAsync(dto);
        return Created($"/api/customer/{id}", null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomersAsync()          
    {
        var customersDtos = await _customerService.GetCustomersAsync();
        return Ok(customersDtos);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerAsync([FromRoute] int id)
    {
        var customersDtos = await _customerService.GetCustomerAsync(id);
        return Ok(customersDtos);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomerAsync([FromRoute] int id ,[FromBody] CustomerDto dto)
    {
        await _customerService.UpdateCustomerAsync(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomerAsync([FromBody] int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }

}