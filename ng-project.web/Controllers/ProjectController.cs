using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
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

		public ProjectController(NgProjectService ProjectService)
		{
			this.NgProjectService = ProjectService;
		}

		#region Services
		private INgProjectService NgProjectService;
		#endregion

		public IActionResult Index()
		{
			return View("Index");
		}

		public IActionResult Info()
		{
			return View("Info");
		}

		[HttpPost]
		public IActionResult Add(Project project)
		{
			project.News = new List<News>();
			NgProjectService.AddProject(project);
			return View("info", project);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
