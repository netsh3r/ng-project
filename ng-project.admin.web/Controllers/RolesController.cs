using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
	public class RolesController : Controller
	{
		public RolesController(IRolesService rolesService)
		{
			this.rolesService = rolesService;
		}
		private IRolesService rolesService;
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult All()
		{
			var model = rolesService.FindAll();
			return View(model);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Roles roles)
		{
			rolesService.Add(roles);
			return RedirectToAction("All");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var model = rolesService.FindById(id);
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Roles roles)
		{
			rolesService.Save(roles);
			return RedirectToAction("All");
		}
	}
}
