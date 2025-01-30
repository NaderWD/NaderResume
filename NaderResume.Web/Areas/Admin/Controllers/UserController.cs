using Microsoft.AspNetCore.Mvc;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Web.Areas.Admin.Controllers
{
    public class UserController(IUserService service) : Controller
    {
        private readonly IUserService _service = service;

        public async Task<IActionResult> List(FilterUserVM filter)
        {
            await _service.Filter(filter);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVM createUser)
        {
            if (!ModelState.IsValid) return View(createUser);

            var result = await _service.CreateUser(createUser);
            switch ((result))
            {
                case CreateUserResult.Success:
                    break;
                case CreateUserResult.Error:
                    break;
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var user = await _service.GetUser(id);
            if (user == null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserVM updateUser)
        {
            if (!ModelState.IsValid) return View(updateUser);

            var result = await _service.UpdateUser(updateUser);
            switch ((result))

            {
                case UpdateUserResult.Success:
                    break;
                case UpdateUserResult.Error:
                    break;
                case UpdateUserResult.UserNotFound:
                    break;
                case UpdateUserResult.EmailDuplicated:
                    break;
                case UpdateUserResult.PhoneDuplicated:
                    break;
            }

            return View();
        }
    }
}
