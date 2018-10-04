using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Business.Contracts;
using Restaurant.Converters;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize(Roles = "User")]
    public class AccountController : Controller
    {
        #region Private services

        private readonly IAccountService _accountService;

        #endregion Private services

        #region Constructor

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(UserViewModel userViewModel)
        {
            var registrationSuccessfull = _accountService.Register(UserModelConverter.ToModel(userViewModel));

            if (!registrationSuccessfull)
            {
                RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = _accountService.Login(UserModelConverter.ToModel(loginViewModel));

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}