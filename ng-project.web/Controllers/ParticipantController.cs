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
		private ISomeModel someModel;
		private INgProjectService projectService;
		public ParticipantController(ISomeModel someMethod, INgProjectService projectService)
		{
			this.someModel = someMethod;
			this.projectService = projectService;
		}
		public IActionResult Participant()
		{
			return View();
		}
		public IActionResult All()
		{
			var model = projectService.GetAll<Participant, int>();
			return View(model);
		}
		public IActionResult Index()
		{	
			return View();
		}
	}
}
