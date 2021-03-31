using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ng_project.Entities;
using ng_project.EntityExpression;
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
		public UserController(INgMainService service, IUserService userService, IProjectService projectService,
			ISkillService skillService,
			IProjectSubTypeService projectSubTypeService,
			ISubscribeService subscribeService,
			IWorkerService participantService,
			IRolesService rolesService,
			ILogger<UserController> logger)
		{
			this.NgProjectService = service;
			this.userService = userService;
			this.projectService = projectService;
			this.skillService = skillService;
			this.projectSubTypeService = projectSubTypeService;
			this.subscribeService = subscribeService;
			this.participantService = participantService;
			this.rolesService = rolesService;
			this.logger = logger;
		}

		#region Services
		private ILogger<UserController> logger;
		private ISkillService skillService;
		private INgMainService NgProjectService;
		private IUserService userService;
		private IProjectService projectService;
		private IProjectSubTypeService projectSubTypeService;
		private ISubscribeService subscribeService;
		private IWorkerService participantService;
		private IRolesService rolesService;
		#endregion
		public IActionResult All()
		{
			var model = NgProjectService.GetAllUsers();
			return View(model);
		}
		[HttpGet]
		public HtmlString GetRoles()
		{
			var roles = rolesService.FindAll();
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
			var role = rolesService.FindById(roleId);
			sb.Append($"<span class=\"participant-skill-item\">{role.Name}</span>");
			//sb.Append($"<input type=\"hidden\" name=\"Roles[{index}].Name\" value=\"{role.Name}\"/>");
			//sb.Append($"<input type=\"hidden\" name=\"Roles[{index}].Id\" value=\"{role.Id}\"/>");
			return new HtmlString(sb.ToString());
		}
		[HttpGet]
		public HtmlString GetSubTypes(int projectTypeId)
		{
			var projectSubTypes = projectSubTypeService.FindAll(t => (t as ProjectSubType).ProjectTypeId == projectTypeId);
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
			var skills = skillService.GetWithInclude(t => new Skill
			{
				Name = t.Name
			}).FindAll().Select(t=> t.Name).ToArray();
			return skills;
		}
		[HttpGet]
		public IActionResult Profile()
		{
			logger.LogInformation("Test Message");
			var user = userService.GetWithInclude(t=> new User
			{ 
				Id = t.Id,
				FirstName = t.FirstName,
				LastName = t.LastName,
				Email = t.Email,
				CreationDate = t.CreationDate,
				Creator = t.Creator,
				Image = t.Image,
				login = t.login,
				Password = t.Password,
				Projects = t.Projects,
				RolesUsers = t.RolesUsers
			}).FindByFuncWithInclude(t => (t as User).login == User.Identity.Name);
			user.Subscriber = subscribeService.GetWithInclude(t => new Subscriber()
			{
				Id = t.Id,
				UserId = t.UserId,
				ProjectSubscribers = t.ProjectSubscribers
			}).FindByFuncWithInclude(t => (t as Subscriber).UserId == user.Id);
			user.Worker = participantService.GetWithInclude(t => new Worker()
			{
				Projects = t.Projects,
				Id =t.Id,
				Skills = t.Skills,
				UserId = t.UserId
			}).FindByFuncWithInclude(s=> (s as Worker).UserId == user.Id);
			return View("Edit",user);
		}
		public IActionResult Profile(int? id)
		{
			logger.LogDebug("Получили профиль пользователя");
			User user = null;
			if(id != null)
            {
				user = userService.GetWithInclude(t => new User
				{
					Id = t.Id,
					FirstName = t.FirstName,
					LastName = t.LastName,
					Email = t.Email,
					CreationDate = t.CreationDate,
					Creator = t.Creator,
					Image = t.Image,
					login = t.login,
					Password = t.Password,
					Projects = t.Projects,
					Subscriber = t.Subscriber,
					Worker = new Worker() 
					{
						Skills = t.Worker.Skills,
						Id = t.Worker.Id,
						Projects = t.Worker.Projects
					}
				}).FindById(id.Value);
			}
			return View(user);		
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
			return new HtmlString(string.Format(@"
				<input type=""hidden"" name=""Worker.Skills[{1}].Id"" value=""{2}"" />
				<input type=""hidden"" name=""Worker.Skills[{1}].Name"" value=""{0}"" />
				<span class=""participant-skill-item"">{0}</span>", skillName,index, newIndex));
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
				// считываем переданный файл в массив байтов
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
			//NgProjectService.Save<Worker, int>(user.Worker);
			user.Worker = null;
			NgProjectService.Save<User, int>(user);
			user.Projects = projectService.FindAll(t=> t.UserId == user.Id).ToList();
			user.Image = NgProjectService.FindByFunc<Image, int>(t=> t.UserId == user.Id);
			var newuser = userService.GetWithInclude(UserExpression.Main())
				.FindByFuncWithInclude(UserExpression.FindByLogin(User.Identity.Name));
			newuser.Subscriber = subscribeService.GetWithInclude(SubscriberExpression.UserSubscriber())
				.FindByFuncWithInclude(SubscriberExpression.FindByUserId(user.Id));
			newuser.Worker = participantService.GetWithInclude(WorkerExpression.UserWorker())
				.FindByFuncWithInclude(WorkerExpression.FindByUserId(user.Id));
			return View("Edit",newuser);
        }
	}
}
