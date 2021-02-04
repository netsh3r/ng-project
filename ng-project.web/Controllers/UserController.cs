using Microsoft.AspNetCore.Mvc;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class UserController : Controller
	{
		public UserController(NgProjectService UserService)
		{
			this.NgProjectService = UserService;
		}

		#region Services
		private INgProjectService NgProjectService;
		#endregion
		public IActionResult All()
		{
			var model = NgProjectService.GetAllUsers();
			return View(model);
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Edit()
		{
			return View();
		}
	}
}
