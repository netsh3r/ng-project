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
	/// <summary>
	/// Контроллер новостей
	/// </summary>
	public class NewsController : Controller
	{

		public IProjectService ProjectService { get; set; }

		/// <summary>
		/// Добавить новости
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
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
			var project = ProjectService.FindById(model.ProjectId);
			return RedirectToAction("Info", "Project", project);
		}
	}
}
