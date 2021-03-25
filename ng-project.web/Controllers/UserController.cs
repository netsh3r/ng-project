using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class UserController : Controller
	{
		public UserController(INgMainService service, IUserService userService, IProjectService projectService,
			ISkillService skillService)
		{
			this.NgProjectService = service;
			this.userService = userService;
			this.projectService = projectService;
			this.skillService = skillService;
		}

		#region Services
		private ISkillService skillService;
		private INgMainService NgProjectService;
		private IUserService userService;
		private IProjectService projectService;
		#endregion
		public IActionResult All()
		{
			var model = NgProjectService.GetAllUsers();
			return View(model);
		}
		[HttpGet]
		public IActionResult Profile()
		{
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
				Subscriber = t.Subscriber,
				Worker = t.Worker
			}).FindByFunc(t => t.login == User.Identity.Name);
			return View("Edit",user);
		}
		public IActionResult Profile(int? id)
		{

			User user = null;
			if(id != null)
            {
				//user = NgProjectService.FindUserById(id.Value);
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
					Worker = t.Worker
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
		public HtmlString GetSkillsBlock(int index)
		{
			return new HtmlString(string.Format(@"
<div class=""input-group mb-3 skill_{0}"">
	<input name=""Participant.Skills[{0}].Name"" type =""text"" class=""form-control"" value ="""" />
	<span class=""input-group-text btn btn-danger"" onclick=""deleteSkill({0})"">
		<svg xmlns=""http://www.w3.org/2000/svg"" width =""16"" height =""16"" fill=""currentColor"" class=""bi bi-x-octagon"" viewBox=""0 0 16 16"" >
			<path d=""M4.54.146A.5.5 0 0 1 4.893 0h6.214a.5.5 0 0 1 .353.146l4.394 4.394a.5.5 0 0 1 .146.353v6.214a.5.5 0 0 1-.146.353l-4.394 4.394a.5.5 0 0 1-.353.146H4.893a.5.5 0 0 1-.353-.146L.146 11.46A.5.5 0 0 1 0 11.107V4.893a.5.5 0 0 1 .146-.353L4.54.146zM5.1 1L1 5.1v5.8L5.1 15h5.8l4.1-4.1V5.1L10.9 1H5.1z"" />
			<path d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"" />
		</svg>
	</span>
</div>
", index));
		}
		[HttpGet]
		public string GetAvatar(byte[] image)
		{
			return Convert.ToBase64String(image);
		}

		[HttpGet]
		public HtmlString AddNewSkill(int index, string name)
		{
			var skill = new Skill();
			skill.Name = name;
			NgProjectService.Add<Skill,int>(skill);
			return new HtmlString(
				string.Format(@"
<div class=""participant-skill-item"">
{0}
</div>
",name)
				);
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
			NgProjectService.Save<Worker, int>(user.Worker);
			NgProjectService.Save<User, int>(user);
			user.Projects = projectService.FindAll(t=> t.UserId == user.Id).ToList();
			user.Image = NgProjectService.FindByFunc<Image, int>(t=> t.UserId == user.Id);
			return View("Edit",user);
        }
	}
}
