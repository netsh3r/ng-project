using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Сущность пользователь
	/// </summary>
	public class User : Entity<int>
	{
		/// <summary>
		/// Ссылка на сущность типа подписчик
		/// </summary>
		public Subscriber Subscriber { get; set; }
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
		public List<Project> Projects { get; set; }
	}
}
