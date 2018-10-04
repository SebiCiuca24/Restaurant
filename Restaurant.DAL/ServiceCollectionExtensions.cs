using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.DAL.Context;
using Restaurant.DAL.Contracts;
using Restaurant.DAL.Repositories;

namespace Restaurant.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestaurantDal(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RestaurantDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
