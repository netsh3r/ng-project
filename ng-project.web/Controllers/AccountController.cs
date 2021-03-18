using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using ng_project.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class AccountController : Controller
	{
		private INgMainService service;
		private IUserService UserService;
		public AccountController(INgMainService service, IUserService UserService)
		{
			this.service = service;
			this.UserService = UserService;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var user = UserService.Login(t => t.login == model.Login && t.Password == model.Password);
				if(user != null)
				{
					await Authenticate(model.Login);
				}
				return RedirectToAction("Index", "Home");
			}
			ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			return View(model);
		}

		[HttpGet]
		public IActionResult Registration()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registration(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var user = UserService.Login(t => t.login == model.Login && t.Password == model.Password);
				if (user == null)
				{
					user = new User();
					user.login = model.Login;
					user.Password = model.Password;
					//user.Email = model.Email;
					var email = new Email();
					email.EmailString = model.Email;
					user.Email = email;
					UserService.Registry(user);
					await Authenticate(model.Login);
					return RedirectToAction("Index", "Home");
				}
				else
					ModelState.AddModelError("", "Некорректные логин и(или) пароль");

			}
			return View(model);
		}
		private async Task Authenticate(string userName)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
			};
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}
