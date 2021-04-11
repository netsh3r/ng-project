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
	//[Authorize(Roles = "admin")]
	/// <summary>
	/// Контроллер участников
	/// </summary>
	public class ParticipantController : Controller
	{
		public IWorkerService ParticipantService { get; set; }
		public INgMainService ProjectService { get; set; }
		public ISkillService SkillService { get; set; }
		public IUserService UserService { get; set; }

		/// <summary>
		/// Получить навыки участника
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public string[] GetSkillItems()
		{
			var skills = SkillService.GetWithInclude(t => new Skill
			{
				Name = t.Name
			}).FindAll().Select(t => t.Name).ToArray();
			return skills;
		}
		
		/// <summary>
		/// Все участники
		/// </summary>
		/// <returns></returns>
		public IActionResult All()
		{
			var model = ParticipantService.GetWithInclude(t => new Worker 
			{
				User = t.User, 
				Id = t.Id,
				SkillWorkers = t.SkillWorkers,
				Projects = t.Projects,
				UserId = t.UserId
			}).FindAll();
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
			var model = UserService.GetWithInclude(t=> new User()
			{ 
				RolesUsers = t.RolesUsers,
				login = t.login,
				Id = t.Id,
				Worker = t.Worker,
				LastName = t.LastName,
				FirstName = t.FirstName
			}).FindAllWithIncude(t => (t as User).RolesUsers.Select(s => s.RolesId).Contains(id));
			return View(model.ToList());
		}
		[HttpGet]
		public IActionResult Info(int id)
		{
			var participant = ParticipantService.GetWithInclude(t=> new Worker()
			{ 
				Id = t.Id,
				User = t.User,
				SkillWorkers = t.SkillWorkers,
				Projects = t.Projects
			}).FindByFuncWithInclude(t=> (t as Worker).Id == id);
			return View(participant);
		}
		[HttpPost]
		public void RemoveSkill(int id)
		{
			ProjectService.RemoveObjectById<Skill,int>(id);
		}
	}
}
