using ng_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Подписчик
	/// </summary>
	public class Subscriber : Entity
	{
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public User User { get; set; }
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Список проектов пользователя
		/// </summary>
		[NotMapped]
		public List<Project> Projects
		{
			get
			{
				return ProjectSubscribers?.Select(t => new Project() 
				{
					Id = t.ProjectsId.Value
				}).ToList();
			}
			set
			{
				Projects = value;
				ProjectSubscribers = Projects?.Select(t => new ProjectSubscriber()
				{
					ProjectsId = Id,
					SubscribersId = t.Id
				}).ToList();
			}
		}
		public virtual List<ProjectSubscriber> ProjectSubscribers { get; set; }
	}
}

