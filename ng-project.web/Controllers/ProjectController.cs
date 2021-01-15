using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	/// <summary>
	/// Контроллер с проектами
	/// </summary>
	public class ProjectController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Info()
		{
			return View();
		}
	}
}
