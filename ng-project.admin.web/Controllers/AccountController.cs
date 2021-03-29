using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using ng_project.admin.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ng_project.Models;

namespace ng_project.admin.web.Controllers
{
	public class AccountController : Controller
	{
		private INgMainService service;
		private IUserService UserService;
		private IRolesService rolesService;
		public AccountController(INgMainService service, IUserService UserService,
			IRolesService rolesService)
		{
			this.service = service;
			this.UserService = UserService;
			this.rolesService = rolesService;
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
				var tt = rolesService.GetWithInclude(t => new Roles()
				{
					Id = t.Id,
					Name = t.Name,
					RolesUsers = t.RolesUsers
				}).FindAll().ToList();
				var roles = tt.Where(t => t.Users != null && t.Users.Count > 0
				&& t.Users.Select(s => s.Id).ToList().Contains(user.Id)).ToList();
				user.RolesUsers = roles?.Select(t => new RolesUser()
				{
					RolesId = t.Id,
					UsersId = user.Id
				}).ToList() ?? new List<RolesUser>();
				//user.Roles = roles.Count > 0 ? roles.Where(t => t.Users.Select(s => s.Id).ToList().Contains(user.Id)).ToList() : new List<Roles>();
				//user.Roles = tt.Where(t => t.Users!=null 
				//	&& t.Users.Count > 0
				//	&& t.Users.Select(s => s.Id).ToList().Contains(user.Id)).ToList();
				//var user = UserService.GetWithInclude(t => new User() { Roles = t.Roles }).FindByFuncWithInclude(t => (t as User).login == model.Login && (t as User).Password == model.Password);
				if (user != null)
				{
					await Authenticate(user);
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
					user.Worker = new Worker();
					user.Subscriber = new Subscriber();
					UserService.Registry(user);
					await Authenticate(user);
					return RedirectToAction("Index", "Home");
				}
				else
					ModelState.AddModelError("", "Некорректные логин и(или) пароль");

			}
			return View(model);
		}
		private async Task Authenticate(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.login)
			};
			if (user.Roles != null)
			{
				foreach (var role in user.Roles)
				{
					claims.Add(new Claim(ClaimTypes.Role, role.Name));
				}
			}

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
