using Restaurant.DAL.Context;
using Restaurant.DAL.Contracts;
using Restaurant.DAL.Models;
using System.Linq;

namespace Restaurant.DAL.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(RestaurantDbContext restaurantDbContext) : base(restaurantDbContext)
        {
        }

        public Role GetRoleByName(string name)
        {
            return _restaurantDbContext.Roles.SingleOrDefault(r => r.RoleName == name);
        }
    }
}
