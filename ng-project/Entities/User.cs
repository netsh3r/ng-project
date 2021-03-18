using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Сущность пользователь
	/// </summary>
	public class User : Entity<int>
	{
		[Display(Name = "Логин")]
		public string login { get; set; }
		[Display(Name = "Имя")]
		public string FirstName { get; set; }
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }
		[Display(Name = "Пароль")]
		public string Password { get; set; }
		public Email Email { get; set; }
		public Participant Participant { get; set; } = new Participant();

		//TODO:Ввести переменную с ролью a.k.a "геймдир, лид, художник анимации" (сделать enum)


	}
}
