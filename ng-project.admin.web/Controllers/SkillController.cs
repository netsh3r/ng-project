using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.admin.web.Controllers
{
	[Authorize]
	public class SkillController : Controller
	{
		public SkillController(ISkillService skillService)
		{
			this.skillService = skillService;
		}
		private ISkillService skillService;
		public IActionResult All()
		{
			var model = skillService.FindAll();
			return View(model);
		}
		
		[HttpPost]
		public IActionResult Add(Skill skill)
		{
			return View();
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
