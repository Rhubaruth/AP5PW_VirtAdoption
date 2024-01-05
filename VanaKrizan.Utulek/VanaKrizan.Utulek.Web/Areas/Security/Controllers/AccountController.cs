using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;
using VanaKrizan.Utulek.Web.Controllers;

namespace VanaKrizan.Utulek.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService security)
        {
            this.accountService = security;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterLoginViewModel registerVM)
        {
            if(registerVM.Register == null)
                return View();


			if (ModelState.IsValid)
            {
                string[] errors = await accountService.Register(registerVM.Register, Roles.Customer);

                if (errors == null)
                {
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        Username = registerVM.Register.Username,
                        Password = registerVM.Register.Password
                    };

                    bool isLogged = await accountService.Login(loginVM);
                    if (isLogged)
                        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
                    else
                        return RedirectToAction(nameof(Login));
                }
                else
                {
                    //error to ViewModel
                    ViewBag.Errors = errors;
                }

            }

            return View(registerVM.Register);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool isLogged = await accountService.Login(loginVM);
                if (isLogged)
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });

                loginVM.LoginFailed = true;
            }

            return View(loginVM);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
        }

		public IActionResult Prihlaseni()
		{
			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> Prihlaseni(LoginViewModel loginVM)
		//{

		//	if (ModelState.IsValid)
		//	{
		//		bool isLogged = await accountService.Login(loginVM);
		//		if (isLogged)
		//			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });

		//		loginVM.LoginFailed = true;
		//	}

		//	return View(loginVM);
		//}

	}
}