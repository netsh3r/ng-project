using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class ParticipantController : Controller
	{

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
