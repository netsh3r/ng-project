using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class User : Entity<long>
	{
		public string login { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public Email Email { get; set; }
	}
}
