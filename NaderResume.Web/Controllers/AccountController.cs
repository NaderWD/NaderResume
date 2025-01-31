using Microsoft.AspNetCore.Mvc;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.ViewModels.AccountVM;

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
                    TempData[SuccessMessage] = "ورود با موفقیت انجام شد";
                    return View(result);

                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است لططفا مجددا تلاش کنید";
                    return View(result);

                case LoginResult.UserNotFound:
                    TempData[ErrorMessage]="کاربر یافت نشد";
                    return View(result);
            }        

            return View();
        }
    }
}
