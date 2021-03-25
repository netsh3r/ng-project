using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace ng_project.web.Controllers
{
	/// <summary>
	/// Контроллер с проектами
	/// </summary>
	public class ProjectController : Controller
	{

		public ProjectController(INgMainService ngService
			, IProjectService projectService
			, IUserService userService
			, ISubscribeService subscribeService)
		{
			this.projectService = projectService;
			this.ngService = ngService;
			this.userService = userService;
			this.subscribeService = subscribeService;
		}

		#region Services
		private INgMainService ngService;
		private IProjectService projectService;
		private IUserService userService;
		private ISubscribeService subscribeService;
		#endregion
		[HttpPost]
		public bool IsSubdcribe(int projectId)
		{
			var project = projectService.FindById(projectId);
			var user = userService.FindUser(t => t.login == User.Identity.Name);
			if(project.Subscribers.Select(t=> t.Id).ToList().Contains(user.Subscriber.Id))
			{
				return true;
			}
			return false;
		}
		[HttpPost]
		public void Subscribe(int projectId)
		{
			var user = userService.FindUser(t => t.login == User.Identity.Name);
			projectService.AddSubscribe(projectId, user.Subscriber.Id);
		}
		 
		[HttpPost]
		public IActionResult SendBecome(int projectId, string text)
		{
			var user = userService.FindUser(t => t.login == User.Identity.Name);
			projectService.AddParticipant(projectId, user.Worker.Id);
			return PartialView("Project/SendBecomeSuccess");
		}
		
		public IActionResult All()
		{
			var model = projectService.GetAll();
			return View("All",model);
		}

		[HttpGet]
		[Authorize]
		public IActionResult Edit(int id)
		{
			var model = projectService.GetWithInclude(t=> new Project
			{ 
				Id = t.Id,
				CreationDate = t.CreationDate,
				Description = t.Description,
				MainProjectImage = t.MainProjectImage,
				Name= t.Name,
				News = t.News,
				ProjectImage =t.ProjectImage,
				ProjectType = t.ProjectType,
				ProjectTypeId = t.ProjectTypeId,
				ShortDescription = t.ShortDescription,
				Skills = t.Skills,
				Subscribers = t.Subscribers,
				User = t.User,
				UserId = t.UserId,
				Workers = t.Workers
			}).FindById(id);
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
			var model = projectService.GetWithInclude(t => new Project
			{
				Id = t.Id,
				CreationDate = t.CreationDate,
				Description = t.Description,
				MainProjectImage = t.MainProjectImage,
				Name = t.Name,
				News = t.News,
				ProjectImage = t.ProjectImage,
				ProjectType = t.ProjectType,
				ProjectTypeId = t.ProjectTypeId,
				ShortDescription = t.ShortDescription,
				Skills = t.Skills,
				Subscribers = t.Subscribers,
				User = t.User,
				UserId = t.UserId,
				Workers = t.Workers
			}).FindById(id);
			return View("Info", model);
		}

		[HttpPost]
		public IActionResult Add(Project project)
		{
			project.News = new List<News>();
			ngService.AddProject(project);
			project.User = ngService.FindUserById(project.UserId);
			return View("info", project);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
