using Restaurant.Business.Models;
using Restaurant.Models;

namespace Restaurant.Converters
{
    public static class UserModelConverter
    {
        public static UserViewModel ToViewModel(UserModel userModel)
        {
            if (userModel == null)
            {
                return null;
            }

            return new UserViewModel
            {
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
        }

        public static UserModel ToModel(UserViewModel userViewModel)
        {
            if (userViewModel == null)
            {
                return null;
            }

            return new UserModel
            {
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Password = userViewModel.Password
            };
        }

        public static LoginModel ToModel(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null)
            {
                return null;
            }

            return new LoginModel
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password,
                KeepLoggedIn = loginViewModel.KeepLoggedIn
            };
        }
    }
}
