using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using ng_project.web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class NewsController : Controller
	{
		public NewsController(INgMainService mainService, IProjectService projectService)
		{
			this.mainService = mainService;
			this.projectService = projectService;
		}

		private INgMainService mainService;
		private IProjectService projectService;

		[HttpPost]
		[Authorize]
		public IActionResult AddNews(NewNewsModel model)
		{
			var news = new News()
			{
				ProjectId = model.ProjectId,
				PublishDate = DateTime.Now,
				Title = model.Title,
				Text = model.Description
			};
			if (model.ImageDataLocal != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(model.ImageDataLocal.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)model.ImageDataLocal.Length);
				}
				if (news.NewsImage == null)
				{
					news.NewsImage = new NewsImage();
				}

				news.NewsImage.Data = imageData;
			}
			mainService.Add<News, int>(news);
			var project = projectService.FindById(model.ProjectId);
			return RedirectToAction("Info", "Project", project);
		}
	}
}
