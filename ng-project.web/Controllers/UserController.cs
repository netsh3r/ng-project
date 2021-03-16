using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Controllers
{
	public class UserController : Controller
	{
		public UserController(INgProjectService service, IUserService userService)
		{
			this.NgProjectService = service;
			this.userService = userService;
		}

		#region Services
		private INgProjectService NgProjectService;
		private IUserService userService;
		#endregion
		public IActionResult All()
		{
			var model = NgProjectService.GetAllUsers();
			return View(model);
		}
		[HttpGet]
		public IActionResult Profile()
		{
			var user = userService.FindUser(t => t.login == User.Identity.Name);
			return View("Edit",user);
		}
		public IActionResult Profile(int? id)
		{

			User user = null;
			if(id != null)
            {
				user = NgProjectService.FindUserById(id.Value);
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
<input name=""Participant.Skills[{0}].Name"" type=""text"" class=""form-control""/>
",index));
		}

		[HttpPost]
		public IActionResult SaveUser(User user)
        {
			//var email = NgProjectService.FindByFunc<Email, int>(t => t.Id == user.Email.Id);
			//if(email == null)
			//{
			//	email = new Email() { EmailString = user.Email.EmailString};
			//}
			//email.UserId = user.Id;
			//user.Email = email;
			//if (user.Participant.Skills.Count > 0)
			//{
			//	foreach (var skill in user.Participant.Skills.Where(t => t.Id == 0))
			//	{
			//		NgProjectService.Add<Skills, int>(skill);
			//	}
			//}
			user.Participant.UserId = user.Id;
			NgProjectService.Save<Participant, int>(user.Participant);
			NgProjectService.Save<User, int>(user);
			return View("Profile",user);
        }
	}
}
