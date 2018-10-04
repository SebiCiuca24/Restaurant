using Restaurant.Business.Models;

namespace Restaurant.Utils
{
    public interface IAuthentificator
    {
        void Authenticate(UserModel userViewModel);
        void Logout();
    }
}
