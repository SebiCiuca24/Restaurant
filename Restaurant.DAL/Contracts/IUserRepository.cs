using Restaurant.DAL.Models;

namespace Restaurant.DAL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);

        User RegisterUser(User user);
    }
}
