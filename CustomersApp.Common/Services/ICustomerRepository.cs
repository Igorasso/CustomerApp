using CustomersApp.Common.Models;

namespace CustomersApp.Common.Services;

public interface ICustomerRepository
{
    public Task<int> CreateCustomerAsync(CustomerDto dto);
    public Task<CustomerDto?> GetCustomerAsync(int id);
    public Task<IList<CustomerDto>> GetCustomersAsync();
    public Task UpdateCustomerAsync(int id, CustomerDto dto);
    public Task DeleteCustomerAsync(int id);
}