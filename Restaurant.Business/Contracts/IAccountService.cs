using Restaurant.Business.Models;

namespace Restaurant.Business.Contracts
{
    public interface IAccountService
    {
        bool Register(UserModel userModel);

        UserModel Login(LoginModel loginModel);
    }
}
