using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class Email : Entity<long>
	{
		public User User { get; set; }
		public long UserId { get; set; }
		public string EmailString { get; set; }
	}
}
