using Microsoft.AspNetCore.Html;
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
	/// Контроллер для работы с уведомлениями
	/// </summary>
	public class NotifyController : Controller
	{
		public INotifyService NotifyService { get; set; }
		public IProjectService ProjectService { get; set; }
		public IUserService UserService { get; set; }
		public IActionResult Index()
		{
			var user = UserService.Find(t => t.login == User.Identity.Name);
			var model = NotifyService
				.Include(t=> t.Recipient)
				.Include(t=> t.Sender)
				.Include(t=> t.Project)
				.FindAll(t => t.RecipientId == user.Id);
			return View(model);
		}
		public IActionResult GetProject(int notifyId)
		{
			if(notifyId == 0)
				return PartialView("Notify/NotProject");

			var model = NotifyService
				.Include(t => t.Recipient)
				.Include(t => t.Sender)
				.Include(t => t.Project)
				.FindById(notifyId);

			return PartialView("Notify/Message", model);
		}
		public IActionResult SetResult(int id, bool isSuccess)
		{
			var model = NotifyService
				.Include(t => t.Recipient)
				.Include(t => t.Sender)
				.Include(t => t.Project)
				.FindById(id);
			
			if (isSuccess)
			{
				var sender = UserService.Include(t => t.Worker).FindById(model.SenderId);
				ProjectService.AddParticipant(model.ProjectId, sender.Worker.Id);
			}

			NotifyService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
