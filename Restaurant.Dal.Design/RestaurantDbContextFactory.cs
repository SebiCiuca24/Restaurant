using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Restaurant.DAL.Context;

namespace Restaurant.Dal.Design
{
    public class RestaurantDbContextFactory : IDesignTimeDbContextFactory<RestaurantDbContext>
    {
        public RestaurantDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RestaurantDbContext>();

            builder.UseSqlServer("Data Source=SCIUCA-WIN\\SEBASTIANCIUCA;Integrated Security=False;User ID=sa;Password=B28lU5J9q;Connect Timeout=30;Database=Restaurant",
                b => b.MigrationsAssembly("Restaurant.Dal.Design"));
            
            return new RestaurantDbContext(builder.Options);
        }       
    }
}
