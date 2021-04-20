using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Models;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ng_project.admin.web.Controllers
{
	[Authorize]
	public class ProjectController : Controller
	{
		public ProjectController(IProjectService projectService,
			IProjectTypeService projectTypeService,
			IProjectSubTypeService projectSubTypeService,
			IRolesService rolesService,
			INgMainService NgProjectService)
		{
			this.projectService = projectService;
			this.projectTypeService = projectTypeService;
			this.projectSubTypeService = projectSubTypeService;
			this.rolesService = rolesService;
			this.NgProjectService = NgProjectService;
		}
		private IProjectService projectService;
		private IProjectTypeService projectTypeService;
		private IProjectSubTypeService projectSubTypeService;
		private IRolesService rolesService;
		private INgMainService NgProjectService;
		public IActionResult All()
		{
			var model = projectService.FindAll();
			return View();
		}
		[HttpGet]
		public HtmlString GetRoles()
		{
			var roles = rolesService.FindAll();
			var sb = new StringBuilder();
			sb.Append("<div class=\"input-group\">");
			sb.Append(@"<select class=""form-control"" id=""select-roles"" name=""select-roles"">");
			foreach (var role in roles)
			{
				sb.Append($"<option value=\"{role.Id}\">{role.Name}</option >");
			}
			sb.Append("</select>");
			sb.Append(@"<span class=""input-group-text add-skills-btn BlueThemeColor AddRole"">
		Добавить
	</span>");
			sb.Append("</div>");
			return new HtmlString(sb.ToString());
		}
		[HttpGet]
		public HtmlString SetRoles(int roleId, int projectTypeId)
		{
			var lastRole = NgProjectService.FindByFunc<ProjectTypeRoles, int>(t => t.RolesId == roleId && t.ProjectTypeId == projectTypeId);
			if (lastRole != null)
			{
				return new HtmlString("");
			}
			NgProjectService.Add<ProjectTypeRoles, int>(new ProjectTypeRoles()
			{
				RolesId = roleId,
				ProjectTypeId = projectTypeId
			});
			var sb = new StringBuilder();
			var role = rolesService.Find(t=> t.Id == roleId);
			sb.Append($"<span class=\"participant-skill-item\">{role.Name}</span>");
			return new HtmlString(sb.ToString());
		}
		[HttpGet]
		public IActionResult EditProjectType(int id)
		{
			var model = projectTypeService
				.Include(t => t.ProjectSubType)
				.Include(t => t.ProjectTypesRoles)
				.Find(t => t.Id == id);

			model.ProjectSubType = projectSubTypeService.FindAll(t => t.ProjectTypeId == model.Id).ToList();
			return View(model);
		}
		[HttpPost]
		public IActionResult EditProjectType(ProjectType projectType)
		{
			projectTypeService.Save(projectType);
			return RedirectToAction("AllProjectType");
		}
		[HttpGet]
		public IActionResult AllProjectType()
		{
			var model = projectTypeService.FindAll();
			return View(model);
		}
		[HttpGet]
		public IActionResult AllProjectSubType()
		{
			var model = projectSubTypeService.FindAll();
			return View(model);
		}
		[HttpGet]
		public IActionResult EditProjectSubType(int id)
		{
			var model = projectSubTypeService.Find(t=> t.Id == id);
			model.ProjectType = projectTypeService.Find(t=> t.Id == model.ProjectTypeId);
			return View(model);
		}
		[HttpPost]
		public IActionResult EditProjectSubType(ProjectSubType projectSubType)
		{
			projectSubTypeService.Save(projectSubType);
			return RedirectToAction("AllProjectSubType");
		}
		[HttpGet]
		public IActionResult AddProjectType()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddProjectType(ProjectType projectType)
		{
			projectTypeService.Add(projectType);
			return RedirectToAction("AllProjectType");
		}
		[HttpGet]
		public HtmlString AddNewSubType(string subTypeName, int index, int projectTypeId)
		{
			var newIndex = projectSubTypeService.Add(new ProjectSubType()
			{
				Name = subTypeName,
				ProjectTypeId= projectTypeId
			});
			return new HtmlString(string.Format(@"
				<input type=""hidden"" name=""ProjectSubType[{1}].Id"" value=""{2}"" />
				<input type=""hidden"" name=""ProjectSubType[{1}].Name"" value=""{0}"" />
				<span class=""participant-skill-item"">{0}</span>", subTypeName, index, newIndex));
		}
	}
}
