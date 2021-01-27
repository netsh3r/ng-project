using Microsoft.AspNetCore.Mvc;
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
		public ParticipantController(ISomeModel someMethod, NgProjectService UserService)
		{
			this.someModel = someMethod;
		}
		public IActionResult Participant()
		{
			return View();
		}
		public IActionResult All()
		{
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
