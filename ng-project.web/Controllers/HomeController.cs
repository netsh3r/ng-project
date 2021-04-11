using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ng_project.Entities;
using ng_project.Services;
using ng_project.web.Components;
using ng_project.web.Models;

namespace ng_project.web.Controllers
{
	public class HomeController : Controller
	{
		public IProjectService ProjectService { get; set; }
		public IUserService UserService { get; set; }
		public UserTestComponent userTestComponent { get; set; }

		public IActionResult Index()
		{
			var model = ProjectService.GetAll();
			return View(model.ToList());
		}
	}
}
