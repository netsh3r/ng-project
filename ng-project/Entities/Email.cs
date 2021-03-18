using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ng_project.Entities
{
	public class Email : Entity<int>
	{
		public User User { get; set; }
		public int UserId { get; set; }
		[Display(Name = "Email")]
		public string EmailString { get; set; }
	}
}
