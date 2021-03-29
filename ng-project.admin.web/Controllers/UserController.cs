using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.EntityExpression;
using ng_project.Models;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.admin.web.Controllers
{
	public class UserController : Controller
	{
		public UserController(IUserService userService
			, IRolesService rolesService
			, IWorkerService workerService
			, ISubscribeService subscribeService
			, IProjectService projectService)
		{
			this.userService = userService;
			this.rolesService = rolesService;
			this.workerService = workerService;
			this.subscribeService = subscribeService;
			this.projectService = projectService;
		}
		private IUserService userService;
		private IRolesService rolesService;
		private IWorkerService workerService;
		private ISubscribeService subscribeService;
		private IProjectService projectService;
		[HttpGet]
		public string[] GetRolesItems()
		{
			var roles = rolesService.FindAll().Select(t=> t.Name).ToArray();
			return roles;
		}
		public IActionResult DeleteUser(int id)
		{
			var worker = workerService.FindByFunc(t => t.UserId == id);
			var sub = subscribeService.FindByFunc(t => t.UserId == id);
			if(worker != null)
			{
				workerService.Delete(worker.Id);
			}
			if(sub != null)
			{
				var projects = projectService.FindAll(t => t.UserId == id);
				foreach(var proj in projects)
				{
					projectService.RemoveLink(new ProjectSubscriber()
					{ 
						ProjectsId = proj.Id,
						SubscribersId = sub.Id
					});
				}
				subscribeService.Delete(sub.Id);
			}
			userService.Delete(id);
			return RedirectToAction("All");
		}
		[HttpPost]
		public HtmlString AddNewRole(string roleName, int index)
		{
			var model = rolesService.FindByFunc(t => t.Name == roleName);
			int modelId = 0;
			if(model == null)
			{
				modelId = rolesService.Add(new Roles()
				{
					Name = roleName
				});
				return new HtmlString(string.Format(@"
<input type=""hidden"" name=""Roles[{0}].Id"" value=""{1}"" />
<input type=""hidden"" name=""Roles[{0}].Name"" value=""{2}"" />
<span class=""participant-skill-item"">{2}</span>
", index, modelId, roleName));
			}
			return new HtmlString(string.Format(@"
<input type=""hidden"" name=""Roles[{0}].Id"" value=""{1}"" />
<input type=""hidden"" name=""Roles[{0}].Name"" value=""{2}"" />
<span class=""participant-skill-item"">{2}</span>
", index, model.Id, model.Name));
		}
		[HttpGet]
		public IActionResult All()
		{
			var model = userService.FindAll();
			return View(model);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var model = userService.GetWithInclude(UserExpression.Main()).FindByFuncWithInclude(t=> (t as User).Id == id);
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(User user)
		{
			userService.Save(user);
			return RedirectToAction("All");
		}
	}
}
