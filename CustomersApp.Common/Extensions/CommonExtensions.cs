using CustomersApp.Common.Services;
using CustomersApp.Database.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerApp Api", Version = "v1" });
            });

            return services;
        }
    }

}
