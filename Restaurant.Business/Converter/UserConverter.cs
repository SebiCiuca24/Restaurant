using Restaurant.Business.Models;
using Restaurant.DAL.Models;

namespace Restaurant.Business.Converter
{
    public static class UserConverter
    {
        public static User ToEntity(UserModel userModel)
        {
            if (userModel == null)
            {
                return null;
            }

            return new User
            {
                ConfirmationDate = userModel.ConfirmationDate,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                Id = userModel.Id,
                IsConfirmed = userModel.IsConfirmed,
                LastName = userModel.LastName,
                Password = userModel.Password,
                RegisterDate = userModel.RegisterDate,
                RoleId = userModel.RoleId
            };
        }

        public static UserModel ToModel(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserModel
            {
                ConfirmationDate = user.ConfirmationDate,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                IsConfirmed = user.IsConfirmed,
                LastName = user.LastName,
                Password = user.Password,
                RegisterDate = user.RegisterDate,
                RoleId = user.RoleId,
                RoleName = user.Role?.RoleName                
            };
        }
    }
}
