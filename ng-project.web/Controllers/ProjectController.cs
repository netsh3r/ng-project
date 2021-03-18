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

		public ProjectController(INgProjectService projectService)
		{
			this.projectService = projectService;
		}

		#region Services
		private INgProjectService projectService;
		#endregion

		public IActionResult All()
		{
			var model = projectService.GetAll<Project, int>();
			return View("All",model);
		}

		public IActionResult Info()
		{
			return View("Info");
		}

		[HttpPost]
		public IActionResult Add(Project project)
		{
			project.News = new List<News>();
			projectService.AddProject(project);
			return View("info", project);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
