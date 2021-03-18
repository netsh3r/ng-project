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
		public Image Image { get; set; }
		[NotMapped]
		public IFormFile ImageDataLocal { get; set; }
		[Display(Name = "Логин")]
		public string login { get; set; }
		[Display(Name = "Имя")]
		public string FirstName { get; set; }
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }
		[Display(Name = "Пароль")]
		public string Password { get; set; }
		public Email Email { get; set; }
		public Participant Participant { get; set; }
		public List<Project> Projects { get; set; }
		//TODO:Ввести переменную с ролью a.k.a "геймдир, лид, художник анимации" (сделать enum)


	}
}
