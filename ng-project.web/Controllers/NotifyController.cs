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
		public IUserService UserService { get; set; }
		public IActionResult Index()
		{
			var user = UserService.FindByFunc(t => t.login == User.Identity.Name);
			var model = NotifyService.GetWithIncludes(t => new Notify()
			{
				Id = t.Id,
				IsReading = t.IsReading,
				Message = t.Message,
				Recipient = t.Recipient,
				SendDate = t.SendDate,
				Sender = t.Sender
			}).FindAllWithIncude(t=> (t as Notify).RecipientId == user.Id);
			return View(model);
		}

	}
}
