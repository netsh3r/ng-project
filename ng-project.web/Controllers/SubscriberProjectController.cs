using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class SubscriberProjectController : Controller
	{
		#region
		public IUserService UserService { get; set; }
		#endregion
		public IActionResult Index()
		{
			var user = UserService.GetWithIncludes(t =>
				new User
				{
					Subscriber = new Subscriber()
					{
						Projects = t.Subscriber.Projects
					}
				}).FindByFunc(t=> (t as User).login == User.Identity.Name);
			return View(user.Subscriber);
		}
	}
}
