using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Models;
using ng_project.Services;
using ng_project.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	/// <summary>
	/// Контроллер для авторизации\регистрации
	/// </summary>
	public class AccountController : Controller
	{
		public INgMainService MainService { get; set; }
		public IUserService UserService { get; set; }
		public IRolesService RolesService { get; set; }

		/// <summary>
		/// Получить представление для авторизации
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		/// <summary>
		/// Авторизоваться
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var user = UserService.Login(t => t.login == model.Login && t.Password == model.Password);
				var tt = RolesService.Include(t=> t.RolesUsers).FindAll().ToList();
				var roles = tt.Where(t => t.Users != null && t.Users.Count > 0
					&& t.Users.Select(s => s.Id).ToList().Contains(user.Id))?.ToList() ?? null;
				if(roles != null && roles.Count > 0)
                {
					user.RolesUsers = roles.Select(t => new RolesUser()
					{
						RolesId = t.Id,
						UsersId = user.Id
					}).ToList() ?? null;
				}
				
				if (user != null)
				{
					await Authenticate(user);
					return RedirectToAction("Index", "Home");
				}
				
			}
			ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			return View(model);
		}

		/// <summary>
		/// Получить представление регистрации
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Registration()
		{
			return View();
		}

		/// <summary>
		/// Зарегистрироваться
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
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
				{
					ModelState.AddModelError("", "Такой пользователь уже существует");
				}

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
					var roleName = RolesService.FindById(role.Id);
					claims.Add(new Claim(ClaimTypes.Role, roleName.Name));
				}
			}

			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		/// <summary>
		/// Выйти
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}