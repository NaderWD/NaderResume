﻿using Microsoft.AspNetCore.Mvc;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Web.Areas.Admin.Controllers
{
    public class UserController(IUserService service) : Controller
    {
        private readonly IUserService _service = service;

        public async Task<IActionResult> List()
        {
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

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var user = await _service.GetUser(id);
            if (user == null) return NotFound();

            //await _service.UpdateUser(user);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserVM updateUser)
        {
            if (!ModelState.IsValid) return View(updateUser);

            return View();
        }
    }
}
