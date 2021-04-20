using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using ng_project.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	/// <summary>
	/// Контроллер участников
	/// </summary>
	public class ParticipantController : Controller
	{
		public IWorkerService ParticipantService { get; set; }
		public IProjectService ProjectService { get; set; }
		public ISkillService SkillService { get; set; }
		public IUserService UserService { get; set; }
		public INotifyService NotifyService { get; set; }

		[HttpPost]
		public IActionResult SendBecome(int ProjectId, string SendText)
		{
			var project = ProjectService.FindById(ProjectId);
			var user = UserService.Find(t => t.login == User.Identity.Name);
			NotifyService.Add(new Notify()
			{
				IsReading = false,
				Message = SendText,
				ProjectId = ProjectId,
				SendDate = DateTime.Now,
				RecipientId = project.UserId,
				SenderId = user.Id
			});
			return RedirectToAction("All");
		}

		/// <summary>
		/// Получить навыки участника
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public string[] GetSkillItems()
		{
			var skills = SkillService.FindAll().Select(t => t.Name).ToArray();
			return skills;
		}
		
		/// <summary>
		/// Все участники
		/// </summary>
		/// <returns></returns>
		public IActionResult All()
		{
			var model = ParticipantService
				.Include(t => t.SkillWorkers)
				.Include(t => t.Projects)
				.Include(t => t.User)
				.FindAll();
			return View(model.ToList());
		}

		/// <summary>
		/// Получить список 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Index(int id)
		{
			var model = UserService
				.Include(t => t.Email)
				.Include(t => t.Worker)
				.Include(t => t.Creator)
				.Include(t => t.Projects)
				.Include(t => t.RolesUsers)
				.FindAll(t => t.RolesUsers.Select(s => s.RolesId).Contains(id));
			return View(model.ToList());
		}
		[HttpGet]
		public IActionResult Info(int id)
		{
			var participant = ParticipantService
				.Include(t => t.User)
				.Include(t=> t.SkillWorkers)
				.FindById(id);
			return View(participant);
		}
		[HttpPost]
		public void RemoveSkill(int id)
		{
			SkillService.Delete(id);
		}
	}
}
