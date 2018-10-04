using Restaurant.DAL.Context;
using Restaurant.DAL.Contracts;
using Restaurant.DAL.Models;
using System.Linq;

namespace Restaurant.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Constructor 
        public UserRepository(RestaurantDbContext restaurantDbContext) : base(restaurantDbContext)
        {
        }
        #endregion Constructor

        public User GetUserByEmail(string email)
        {
            return _restaurantDbContext.Users?.SingleOrDefault(u => string.Equals(u.Email, email, System.StringComparison.OrdinalIgnoreCase));
        }

        public User RegisterUser(User user)
        {
            return Add(user);
        }
    }
}
