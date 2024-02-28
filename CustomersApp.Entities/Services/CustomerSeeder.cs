using Microsoft.EntityFrameworkCore;
using CustomersApp.Database.Entities;

namespace CustomersApp.Database.Services;
public class CustomerSeeder
{
    private readonly CustomerDbContext _dbContext;

    public CustomerSeeder(CustomerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            _dbContext.Database.Migrate();
            if (!_dbContext.Customers.Any())
            {
                var customers = GetCustomers();
                _dbContext.Customers.AddRange(customers);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Customer> GetCustomers()
    {
        List<Customer> customers = new List<Customer>() {
         new Customer()
            {
                Name = "McDonalds",
                Address = new Address()
                    {
                    Street = "G³ogowska",
                    City = "Poznañ",
                    Country = "Polska",
                    PostalCode = "00-000"
                    },
                NIP = "9999999999"
             },

            new Customer()
             {
                Name = "KFC",
                Address = new Address()
                    {
                    Street = "Katowicka",
                    City = "Poznañ",
                    Country = "Polska",
                    PostalCode = "00-000"
                    },
                NIP = "9999999998"
             }};

        return customers;

    }

}