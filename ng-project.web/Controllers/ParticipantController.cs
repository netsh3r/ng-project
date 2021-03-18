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
	public class ParticipantController : Controller
	{
		private IParticipantService participantService;
		private INgMainService projectService;
		public ParticipantController(IParticipantService participantService, INgMainService projectService)
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
			var model = participantService.GetAll();
			return View(model);
		}
		public IActionResult Index()
		{	
			return View();
		}

		[HttpPost]
		public void RemoveSkill(int id)
		{
			projectService.RemoveObjectById<Skills,int>(id);
		}
	}
}
