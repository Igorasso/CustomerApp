using CustomersApp.Common.Services;
using CustomersApp.Database.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CustomersApp.Common.Data.Extensions
{
    public static class CommonExtensions
    {
        public static IServiceCollection AddCommon(
                this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<CustomerSeeder>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }

}
