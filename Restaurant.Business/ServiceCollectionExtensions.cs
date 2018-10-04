using Microsoft.Extensions.DependencyInjection;
using Restaurant.Business.Contracts;
using Restaurant.Business.Services;
using Restaurant.Business.Utils;

namespace Restaurant.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestaurantBusiness(this IServiceCollection services)
        {
            services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
