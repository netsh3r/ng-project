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
	/// Сущность пользователь
	/// </summary>
	public class User : Entity
	{
		public List<Notify> Notifies { get; set; }
		public List<Notify> SenderNotifies { get; set; }
		public List<NewsComment> NewsComments { get; set; }
		/// <summary>
		/// Комментарии пользователя
		/// </summary>
		public List<Comment> Comments { get; set; }
		/// <summary>
		/// Роли
		/// </summary>
		public virtual List<RolesUser> RolesUsers { get; set; } = new List<RolesUser>();
		[NotMapped]
		public List<Roles> Roles
		{
			get
			{
				return RolesUsers.Select(t => new Roles()
				{
					Id = t.RolesId
				}).ToList();
			}
		}
		/// <summary>
		/// Ссылка на сущность типа подписчик
		/// </summary>
		public Subscriber Subscriber { get; set; } = new Subscriber();
		/// <summary>
		/// Ссылка на сущность типа Сотрудник
		/// если пользователь собирается быть участником
		/// </summary>
		public Worker Worker { get; set; }
		/// <summary>
		/// Ссылка на сущность типа Создатель
		/// если пользователь собирается создавать проекты
		/// </summary>
		public Creator Creator { get; set; }
		/// <summary>
		/// Дата создания страницы пользователя
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// Фотография
		/// </summary>
		public Image Image { get; set; }
		[NotMapped]
		public IFormFile ImageDataLocal { get; set; }
		/// <summary>
		/// Логин
		/// </summary>
		[Display(Name = "Логин")]
		public string login { get; set; }
		/// <summary>
		/// Имя
		/// </summary>
		[Display(Name = "Имя")]
		public string FirstName { get; set; }
		/// <summary>
		/// Фамилия
		/// </summary>
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }
		/// <summary>
		/// Пароль
		/// </summary>
		[Display(Name = "Пароль")]
		public string Password { get; set; }
		/// <summary>
		/// Емаил
		/// </summary>
		public Email Email { get; set; }
		/// <summary>
		/// Список созданных проектов пользователя
		/// </summary>
		public virtual List<Project> Projects { get; set; } = new List<Project>();
	}
}
