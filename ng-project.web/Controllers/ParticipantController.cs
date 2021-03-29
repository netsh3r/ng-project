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
	public class ParticipantController : Controller
	{
		private IWorkerService participantService;
		private INgMainService projectService;
		public ParticipantController(IWorkerService participantService, INgMainService projectService)
		{
			this.participantService = participantService;
			this.projectService = projectService;
		}
		public IActionResult Participant()
		{
			return View();
		}
		public IActionResult All()
		{
			var model = participantService.GetWithInclude(t => new Worker 
			{
				User = t.User, 
				Id = t.Id,
				Skills = t.Skills,
				Projects = t.Projects,
				UserId = t.UserId
			}).FindAll();
			return View(model);
		}
		public IActionResult Index()
		{	
			return View();
		}

		[HttpPost]
		public void RemoveSkill(int id)
		{
			projectService.RemoveObjectById<Skill,int>(id);
		}
	}
}
