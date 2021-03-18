using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	/// <summary>
	/// Контроллер с проектами
	/// </summary>
	public class ProjectController : Controller
	{

		public ProjectController(INgMainService ngService, IProjectService projectService)
		{
			this.projectService = projectService;
			this.ngService = ngService;
		}

		#region Services
		private INgMainService ngService;
		private IProjectService projectService;
		#endregion

		public IActionResult All()
		{
			var model = projectService.GetAll();
			return View("All",model);
		}

		[HttpGet]
		[Authorize]
		public IActionResult Edit(int id)
		{
			var model = projectService.FindById(id);
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Project project)
		{
			if (project.ImageDataLocal != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(project.ImageDataLocal.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)project.ImageDataLocal.Length);
				}
				if (project.ProjectImage == null)
				{
					project.ProjectImage = new ProjectImage();
				}

				project.ProjectImage.Data = imageData;
			}
			else
			{
				project.ProjectImage = null;
			}
			if (project.MainImageDataLocal != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(project.MainImageDataLocal.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)project.MainImageDataLocal.Length);
				}
				if (project.MainProjectImage == null)
				{
					project.MainProjectImage = new MainProjectImage();
				}

				project.MainProjectImage.Data = imageData;
			}
			else
			{
				project.MainProjectImage = null;
			}
			ngService.Save<Project, int>(project);
			return Info(project.Id);
		}

		public IActionResult Info(int id)
		{
			var model = projectService.FindById(id);
			return View("Info", model);
		}

		[HttpPost]
		public IActionResult Add(Project project)
		{
			project.News = new List<News>();
			ngService.AddProject(project);
			return View("info", project);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
