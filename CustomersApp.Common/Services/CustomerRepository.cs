using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CustomersApp.Common.Models;
using Microsoft.Extensions.Logging;
using CustomersApp.Database.Entities;

namespace CustomersApp.Common.Services;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(CustomerDbContext dbContext, IMapper mapper, ILogger<CustomerRepository> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> CreateCustomerAsync(CustomerDto dto)
    {
        var customer = _mapper.Map<Customer>(dto);
        var clientExist = await _dbContext.Customers.FirstOrDefaultAsync(c => c.NIP == customer.NIP);
        if (clientExist != null)
           _logger.LogError("Customer already exists in database");

        _dbContext.Add(customer);
        await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Created customer with ID : {customer.Id}");

        return customer.Id;
    }
    public async Task<CustomerDto?> GetCustomerAsync(int id)
    {
        var customer = await _dbContext
       .Customers
       .Include(r => r.Address)
       .FirstOrDefaultAsync(x => x.Id == id);

        if (customer is null)
        {
            _logger.LogError($"Customer with ID : {id} not found");
            return null;
        }

        return _mapper.Map<CustomerDto>(customer);
    }
    public async Task<IList<CustomerDto>> GetCustomersAsync()
    {
        var customers = await _dbContext
       .Customers
       .Include(r => r.Address)
       .ToListAsync();

        return _mapper.Map<List<CustomerDto>>(customers);
    }
    public async Task UpdateCustomerAsync(int id, CustomerDto dto)
    {
        var customer = await _dbContext
          .Customers
          .Include(r => r.Address)
          .FirstOrDefaultAsync(r => r.Id == id);

        if (customer is null)
        {
            _logger.LogError($"Customer with ID : {id} not found");
            return;
        }

        _mapper.Map(dto, customer);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Created customer with ID : {customer.Id}");

    }
    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _dbContext
            .Customers
            .FirstOrDefaultAsync(r => r.Id == id);

        if (customer is null)
        {
            _logger.LogError($"Customer with ID : {id} not found");
            return;
        }
            
        _dbContext.Remove(customer);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Removed customer with ID : {id}");
    }
 

}
