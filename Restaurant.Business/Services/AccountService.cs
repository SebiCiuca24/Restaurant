using Microsoft.AspNetCore.Authorization;
using Restaurant.Business.Contracts;
using Restaurant.Business.Converter;
using Restaurant.Business.Models;
using Restaurant.Business.Utils;
using Restaurant.DAL.Contracts;
using System;
using System.ComponentModel;

namespace Restaurant.Business.Services
{
    public class AccountService : IAccountService
    {
        #region Private services

        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly IRoleRepository _roleRepository;

        #endregion

        #region Constructor

        public AccountService(IUserRepository userRepository, IPasswordEncrypter passwordEncrypter,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _passwordEncrypter = passwordEncrypter;
            _roleRepository = roleRepository;
        }

        #endregion Constructor

        public UserModel Login(LoginModel loginModel)
        {
            var user = _userRepository.GetUserByEmail(loginModel.Email);

            if (user == null)
            {
                return null;
            }

            var encryptedPassword = _passwordEncrypter.EncryptPassword(loginModel.Password);

            if (user.Password == encryptedPassword)
            {
                return UserConverter.ToModel(user);
            }

            return null;
        }

        public bool Register(UserModel userModel)
        {
            var user = _userRepository.GetUserByEmail(userModel.Email);

            if (user != null)
            {
                return false;
            }

            var userRole = _roleRepository.GetRoleByName(EnumHelper.GetAttributeOfType<DescriptionAttribute>(RolesEnum.User)?.Description ?? string.Empty);

            userModel.Password = _passwordEncrypter.EncryptPassword(userModel.Password);
            userModel.RoleId = userRole.Id;
            userModel.RegisterDate = DateTime.UtcNow;

            _userRepository.RegisterUser(UserConverter.ToEntity(userModel));
            _userRepository.SaveChanges();

            return true;
        }
    }
}
