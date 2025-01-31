using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.ViewModels.AccountVM;
using System.Security.Claims;

namespace NaderResume.Web.Controllers
{
    public class AccountController(IUserService service) : SiteBaseController
    {
        private readonly IUserService _service = service;

        public IActionResult Login()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid) return View(model);

            var result = await _service.LoginUser(model);
            switch (result)
            {
                case LoginResult.Success:
#pragma warning disable CS8604 // Possible null reference argument.
                    var user = await _service.GetUserByEmail(model.Email);
                    var claims = new List<Claim>()
                    {
                        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new(ClaimTypes.Name, $"{user.FirstName} ${ user.FirstName}"),
                        new(ClaimTypes.MobilePhone, user.Phone),
                    };
                    var identify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identify);
                    var properties = new AuthenticationProperties { IsPersistent = true };

                    await HttpContext.SignInAsync(principal, properties);
                    TempData[SuccessMessage] = "خوش آمدید";
                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است لططفا مجددا تلاش کنید";
                    return View(result);

                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر یافت نشد";
                    return View(result);
            }

            return View();
        }
    }
}
