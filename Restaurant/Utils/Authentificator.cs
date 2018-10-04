using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Restaurant.Utils
{
    public class Authentificator : IAuthentificator
    {
        #region Private services

        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Private services

        #region Constructor

        public Authentificator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructor
        public void Authenticate(UserModel userModel)
        {
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Role,userModel.RoleName),
               new Claim(ClaimTypes.Email,userModel.Email)
            };

            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddYears(1),
                AllowRefresh = true
            };

            _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
               userPrincipal,
               authProperties).GetAwaiter().GetResult();
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).GetAwaiter().GetResult();
        }
    }
}
