using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
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
		public IActionResult Profile(int? id)
		{

			User user = null;
			if(id != null)
            {
				user = NgProjectService.FindUserById(id.Value);
			}
			return View(user);		
		}
		public IActionResult Edit(int? id)
		{
			User user = null;
			if (id != null)
			{
				user = NgProjectService.FindUserById(id.Value);
			}
			return View(user);
		}

		[HttpPost]
		public IActionResult SaveUser(User user)
        {
			return View("Profile",user);
        }
	}
}
