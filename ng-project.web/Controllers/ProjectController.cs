using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng_project.Entities;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using System.Text;
using ng_project.Models;

namespace ng_project.web.Controllers
{
	/// <summary>
	/// Контроллер с проектами
	/// </summary>
	public class ProjectController : Controller
	{


		#region Services
		public INewsService NewsService { get; set; }
		public INgMainService NgService { get; set; }
		public IProjectService ProjectService { get; set; }
		public IUserService UserService { get; set; }
		public ISubscribeService SubscribeService { get; set; }
		public IProjectSubTypeService ProjectSubTypeService { get; set; }
		public ICommentService CommentService { get; set; }

		#endregion
		[HttpPost]
		public bool IsSubdcribe(int projectId)
		{
			var project = ProjectService.GetWithIncludes(t => new Project()
			{
				Id = t.Id,
				ProjectSubscribers = t.ProjectSubscribers
			}).FindByFuncWithInclude(t => (t as Project).Id == projectId);
			//var project = projectService.FindById(projectId);
			//var user = userService.FindUser(t => t.login == User.Identity.Name);
			var user = UserService.GetWithIncludes(t => new User()
			{
				Projects = t.Projects,
				Subscriber = t.Subscriber,
				Id = t.Id,
				login = t.login
			}).FindByFuncWithInclude(t=> 
				(t as User).login == User.Identity.Name
			);
			if(project.Subscribers.Count()>0 && project.Subscribers.Select(t=> t.Id).ToList().Contains(user.Subscriber.Id))
			{
				return true;
			}
			return false;
		}
		[HttpPost]
		public HtmlString AddComments(int projectId, string text)
		{
			var user = UserService.FindByFunc(t=> t.login == User.Identity.Name);
			CommentService.Add(new Comment()
			{
				ProjectId = projectId,
				Text = text,
				UserId = user.Id ,
				PublishDate = DateTime.Now
			}); 
			return new HtmlString(string.Format(@"
<div class=""item"">
	<div class=""row"">
		<div class=""col-2"">
			<div class=""user-img BlueThemeColor"">

			</div>
		</div>
		<div class=""col-10"">
			<div class=""user-name"">
				{0}
			</div>
			<div class=""comment-text"">
				{1}
			</div>

			<div class=""comment-border""></div>
		</div>
	</div>
</div>
", User.Identity.Name,text));
		}
		[HttpPost]
		public void Subscribe(int projectId)
		{
			//var user = userService.FindUser(t => t.login == User.Identity.Name);
			var user = UserService.GetWithIncludes(t => new User()
			{
				login = t.login,
				Subscriber = t.Subscriber
			}).FindByFuncWithInclude(s=> (s as User).login == User.Identity.Name);
			ProjectService.AddSubscribe(projectId, user.Subscriber.Id);


		}
		[HttpPost]
		public void DeleteSubscribe(int projectId)
		{
			var user = UserService.GetWithIncludes(t => new User()
			{
				login = t.login,
				Subscriber = t.Subscriber
			}).FindByFuncWithInclude(s => (s as User).login == User.Identity.Name);
			var project = ProjectService.GetWithIncludes(t => new Project()
			{
				Id = t.Id,
				ProjectSubscribers = t.ProjectSubscribers
			}).FindByFuncWithInclude(t => (t as Project).Id == projectId);
			var link = project.Subscribers.FirstOrDefault(t => t.Id == user.Subscriber.Id);
			SubscribeService.RemoveLink(new ProjectSubscriber(){ ProjectsId = projectId,SubscribersId= link.Id});
		}

		[HttpPost]
		public IActionResult SendBecome(int projectId, string text)
		{
			var user = UserService.FindUser(t => t.login == User.Identity.Name);
			ProjectService.AddParticipant(projectId, user.Worker.Id);
			return PartialView("Project/SendBecomeSuccess");
		}
		
		public IActionResult All()
		{
			var model = ProjectService.GetAll();
			return View("All",model.ToList());
		}

		[HttpGet]
		[Authorize]
		public IActionResult Edit(int id)
		{
			var model = ProjectService.GetWithIncludes(t=> new Project
			{ 
				Id = t.Id,
				CreationDate = t.CreationDate,
				Description = t.Description,
				MainProjectImage = t.MainProjectImage,
				Name= t.Name,
				News = t.News,
				ProjectImage =t.ProjectImage,
				ProjectType = t.ProjectType,
				ProjectTypeId = t.ProjectTypeId,
				ShortDescription = t.ShortDescription,
				Skills = t.Skills,
				Subscribers = t.Subscribers,
				User = t.User,
				UserId = t.UserId,
				Workers = t.Workers
			}).FindById(id);
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Project project)
		{
			if (project.ImageDataLocal != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(project.ImageDataLocal.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)project.ImageDataLocal.Length);
				}
				if (project.ProjectImage == null)
				{
					project.ProjectImage = new ProjectImage();
				}

				project.ProjectImage.Data = imageData;
			}
			else
			{
				project.ProjectImage = null;
			}
			if (project.MainImageDataLocal != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(project.MainImageDataLocal.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)project.MainImageDataLocal.Length);
				}
				if (project.MainProjectImage == null)
				{
					project.MainProjectImage = new MainProjectImage();
				}

				project.MainProjectImage.Data = imageData;
			}
			else
			{
				project.MainProjectImage = null;
			}
			NgService.Save<Project, int>(project);
			return Info(project.Id);
		}

		public IActionResult Info(int id)
		{
			var model = ProjectService.GetWithIncludes(t => new Project
			{
				Id = t.Id,
				CreationDate = t.CreationDate,
				Description = t.Description,
				MainProjectImage = t.MainProjectImage,
				Name = t.Name,
				News = t.News,
				ProjectImage = t.ProjectImage,
				ProjectType = t.ProjectType,
				ProjectTypeId = t.ProjectTypeId,
				ShortDescription = t.ShortDescription,
				Skills = t.Skills,
				ProjectSubscribers = t.ProjectSubscribers,
				User = t.User,
				UserId = t.UserId,
				Workers = t.Workers,
				Comments = t.Comments.Select(s=> new Comment()
				{ 
					User = s.User,
					Text = s.Text,
					PublishDate = s.PublishDate
				}).ToList()
			}).FindByFuncWithInclude(t=> (t as Project).Id == id);
			return View("Info", model);
		}
		[HttpPost]
		public HtmlString AddNewsPost(int projectId, string text)
		{
			NewsService.Add(new News()
			{
				Text = text,
				ProjectId = projectId
			});
			return new HtmlString(string.Format(@"
<div class=""news-list-item"">
<div class=""text"">
		<div class=""DateTime"">
			{0}
		</div>
		<div class=""news-name"">
			{1}
		</div>
		<div class=""news-description mt-3"">
			{2}			
		</div>
	</div>
</div>
", DateTime.Now.ToShortDateString(),text,text));
		}
		[HttpPost]
		public IActionResult Add(Project project)
		{
			project.News = new List<News>();
			//ngService.AddProject(project);
			ProjectService.Add(project);
			project.User = NgService.FindUserById(project.UserId);
			return View("info", project);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpGet]
		public HtmlString GetSubTypes(int projectTypeId)
		{
			var sb = new StringBuilder();
			sb.Append("<div class=\"d-flex flex-nowrap\">");
			var projectSubTypes = ProjectSubTypeService.FindAll(t => (t as ProjectSubType).ProjectTypeId == projectTypeId);
			var index = 0;
			foreach(var subType in projectSubTypes)
			{
				sb.Append($"<div class=\"project-type-item project_sub_type\" onclick=\"loadProject({projectTypeId},{subType.Id},{index++})\">");
				sb.Append($"<input type=\"hidden\" name=\"project_sub_type_id\" value=\"{subType.Id}\" />");
				sb.Append(@"<div class=""text"">");

				sb.Append($"{subType.Name}");
				sb.Append("</div></div>");
			}
			sb.Append("</div>");
			return new HtmlString(sb.ToString());
		}
		[HttpGet]
		public HtmlString GetProjects(int projectTypeId, int projectSubType)
		{
			var projects = ProjectService
				.FindAll(t => (t as Project).ProjectTypeId == projectTypeId && (t as Project).ProjectSubTypeId == projectSubType);
			var sb = new StringBuilder();
			foreach(var proj in projects)
			{
				proj.User = UserService.FindById(proj.UserId);
				sb.Append("<div class=\"col-md-4 mt-4\">");
				sb.Append($"<div class=\"project-item\" onclick=\"window.location.href='{Url.Action("Info","Project",new { id = proj.Id })}'\">");
				//var hasImage = proj.MainProjectImage != null && proj.MainProjectImage.Data != null;
				//var hasUserImage = proj.User.Image != null && proj.User.Image.Data != null;
				sb.Append($"<div class=\"project-card BlueTheme \">");
				sb.Append("</div>");
				sb.Append($"<div class=\"project-text-block mt-2\">");
				sb.Append($"<div class=\"row\">");
				sb.Append($"<div class=\"col-2\">");
				sb.Append($"<div class=\"profile-img\">");
				if(false)
				{
					sb.Append($"<img src=\"data:image/jpeg;base64,{Convert.ToBase64String(proj.User.Image.Data)}\" />");
				}
				sb.Append("</div>");
				sb.Append("</div>");
				sb.Append($"<div class=\"col-10\">");
				sb.Append($"<div class=\"row\">");
				sb.Append($"<span class=\"project-creator-name\">{proj.User.login}</span>");
				sb.Append("</div>");
				sb.Append($"<div class=\"row\">");
				sb.Append($"<span class=\"project-creator-name\">{proj.Name}</span>");
				sb.Append("</div>");
				sb.Append("</div>");
				sb.Append("</div>");
				sb.Append("</div>");
				sb.Append("</div>");
				sb.Append("</div>");
			}
			return new HtmlString(sb.ToString());
		}
	}
}
