using CustomersApp.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CustomersApp.Database.Extensions
{
    public static class EntitiesExtensions
    {
        public static IServiceCollection AddDatabase(
                this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("CustomerDbConnection"));
            });

            return services;
        }
    }

}
