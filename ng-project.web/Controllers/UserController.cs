using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ng_project.Entities;
using ng_project.EntityExpressions;
using ng_project.Models;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class UserController : Controller
	{

		#region Services
		public ISkillService SkillService { get; set; }
		public INgMainService NgProjectService { get; set; }
		public IUserService UserService { get; set; }
		public IProjectService ProjectService { get; set; }
		public IProjectSubTypeService ProjectSubTypeService { get; set; }
		public ISubscribeService SubscribeService { get; set; }
		public IWorkerService WorkerService { get; set; }
		public IRolesService RolesService { get; set; }
		#endregion
		public IActionResult All()
		{
			var model = NgProjectService.GetAllUsers();
			return View(model);
		}
		[HttpGet]
		public HtmlString GetRoles()
		{
			var roles = RolesService.FindAll();
			var sb = new StringBuilder();
			sb.Append("<div class=\"input-group\">");
			sb.Append(@"<select class=""form-control"" id=""select-roles"" name=""select-roles"">");
			foreach(var role in roles)
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
		public HtmlString SetRoles(int roleId, int userId)
		{
			var lastRole = NgProjectService.FindByFunc<RolesUser, int>(t => t.RolesId == roleId && t.UsersId==userId);
			if(lastRole != null)
			{
				return new HtmlString("");
			}
			NgProjectService.Add<RolesUser, int>(new RolesUser()
			{ 
				RolesId = roleId,
				UsersId = userId
			});
			var sb = new StringBuilder();
			var role = RolesService.Find(t=> t.Id == roleId);
			sb.Append($"<span class=\"participant-skill-item\">{role.Name}</span>");
			return new HtmlString(sb.ToString());
		}
		[HttpGet]
		public HtmlString GetSubTypes(int projectTypeId)
		{
			var projectSubTypes = ProjectSubTypeService.FindAll(t => (t as ProjectSubType).ProjectTypeId == projectTypeId);
			var sb = new StringBuilder();
			sb.Append("<select class=\"form-control\" id=\"ProjectSubTypeId\" name=\"ProjectSubTypeId\">");
			foreach(var subTypeItem in projectSubTypes)
			{
				sb.Append($"<option value=\"{subTypeItem.Id}\">{subTypeItem.Name}</option >");
			}
			sb.Append("</select>");
			return new HtmlString(sb.ToString());
		}
		[HttpGet]
		public string[] GetSkillItems()
		{
			var skills = SkillService.FindAll().Select(t=> t.Name).ToArray();
			return skills;
		}
		[HttpGet]
		public IActionResult Profile()
		{
			var user = UserService
				.Include(t=> t.Email)
				.Include(t => t.Creator)
				.Include(t => t.Projects)
				.Include(t => t.RolesUsers)
				.Find(t => t.login == User.Identity.Name);
			user.Subscriber = SubscribeService
				.Include(t => t.ProjectSubscribers)
				.Find(t => t.UserId == user.Id);
			user.Worker = WorkerService
				.Include(t => t.SkillWorkers)
				.Include(t=> t.SkillWorkers)
				.Include(t => t.Projects)
				.Find(s=> s.UserId == user.Id);
			return View("Edit",user);
		}
		public IActionResult Profile(int? id)
		{
			User user = null;
			if(id != null)
            {
				user = UserService
					.Include(t => t.Email)
					.Include(t => t.Creator)
					.Include(t => t.Projects)
					.Include(t => t.Subscriber)
					.Include(t => t.Worker)
					.FindById(id.Value);
			}
			return View(user);		
		}
		[HttpGet]
		public HtmlString GetSkills(int id)
		{
			var sb = new StringBuilder();
			var skills = SkillService
				.Include(t => t.SkillWorkers)
				.FindAll(t => t.SkillWorkers.Select(s => s.WorkerId).Contains(id));
			foreach(var skill in skills)
			{
				sb.Append($"<span class=\"participant-skill-item\">{skill.Name}</span>");
			}
			return new HtmlString(sb.ToString());
		}
		public IActionResult Edit(int? id)
		{
			User user = null;
			if (id != null)
			{
				user = NgProjectService.FindUserById(id.Value);
			}
			return View(user);
		}

		[HttpGet]
		public HtmlString AddNewSkill(string skillName, int index, int workerId)
		{
			var newIndex = NgProjectService.Add<Skill, int>(new Skill()
			{
				Name = skillName
			}); 

			return new HtmlString(string.Format(@"<span class=""participant-skill-item"">{0}</span>", skillName,index, newIndex));
		}
		[HttpGet]
		public string GetAvatar(byte[] image)
		{
			return Convert.ToBase64String(image);
		}

		[HttpPost]
		public IActionResult SaveUser(User user)
        {
			if(user.ImageDataLocal != null)
			{
				byte[] imageData = null;
				using (var binaryReader = new BinaryReader(user.ImageDataLocal.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)user.ImageDataLocal.Length);
				}
				if (user.Image == null)
				{
					user.Image = new Image();
				}
				
				user.Image.Data = imageData;
			}
			else
			{
				user.Image = null;
			}
			user.Worker.User = user;
			user.RolesUsers = null;
			user.Worker = null;
			NgProjectService.Save<User, int>(user);
			user.Projects = ProjectService.FindAll(t=> t.UserId == user.Id).ToList();
			user.Image = NgProjectService.FindByFunc<Image, int>(t=> t.UserId == user.Id);
			var newuser = UserService
				.Include(t => t.Email)
				.Include(t => t.Creator)
				.Include(t => t.Projects)
				.Include(t => t.RolesUsers)
				.Find(t => t.login == User.Identity.Name);
			newuser.Subscriber = SubscribeService.Include(t => t.ProjectSubscribers).Find(t => t.UserId == user.Id);
			newuser.Worker = WorkerService
				.Include(t => t.Projects)
				.Include(t => t.SkillWorkers)
				.Find(s => s.UserId == user.Id);
			return View("Edit",newuser);
        }
	}
}
