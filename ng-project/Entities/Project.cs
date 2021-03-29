using Microsoft.AspNetCore.Http;
using ng_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Проект
	/// </summary>
	public class Project : Entity
	{
		//public Project()
		//{
		//	Subscribers = ProjectSubscribers.Select(t=> t.Subscribers).ToList();
		//}
		public virtual List<Comment> Comments { get; set; } = new List<Comment>();
		public virtual List<ProjectSubscriber> ProjectSubscribers { get; set; } = new List<ProjectSubscriber>();
		/// <summary>
		/// Тип проекта
		/// </summary>
		public ProjectType ProjectType { get; set; }
		/// <summary>
		/// Тип проекта
		/// </summary>
		public ProjectSubType ProjectSubType { get; set; }
		public int ProjectSubTypeId { get; set; }
		/// <summary>
		/// Идентификатор типа проекта
		/// </summary>
		public int ProjectTypeId { get; set; }
		/// <summary>
		/// Дата создания проекта
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// Необходимые навыки для проекта
		/// </summary>
		public virtual List<Skill> Skills { get; set; }
		/// <summary>
		/// Подписчики 
		/// </summary>
		[NotMapped]
		public List<Subscriber> Subscribers { 
			get 
			{
				return ProjectSubscribers.Select(t => new Subscriber()
				{ 
					Id = t.SubscribersId.Value
				}).ToList();
			}
			set
			{
				ProjectSubscribers = Subscribers?.Select(t => new ProjectSubscriber()
				{
					ProjectsId = Id,
					SubscribersId = t.Id
				}).ToList();
			}
		}
		/// <summary>
		/// Сотрудники проекта
		/// </summary>
		public virtual List<Worker> Workers { get; set; }
		/// <summary>
		/// Обложка
		/// </summary>
		public MainProjectImage MainProjectImage { get; set; }
		[NotMapped]
		public IFormFile MainImageDataLocal { get; set; }
		/// <summary>
		/// Изображение проекта
		/// </summary>
		public ProjectImage ProjectImage { get; set; }
		[NotMapped]
		public IFormFile ImageDataLocal { get; set; }
		/// <summary>
		/// название проекта
		/// </summary>
		[Display(Name="Название проекта")]
		public string Name { get; set; }
		/// <summary>
		/// Описание проекта
		/// </summary>
		[Display(Name="Полное описание проекта")]
		public string Description { get; set; }
		/// <summary>
		/// Краткое описание проекта
		/// </summary>
		[Display(Name="Краткое описание проекта")]
		public string ShortDescription { get; set; }
		/// <summary>
		/// Создатель
		/// </summary>
		public User User { get; set; }
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Новости проекта
		/// </summary>
		public virtual List<News> News { get; set; }
	}
}
