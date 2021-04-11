using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Components
{
	public class UserTestComponent
	{
		public IUserService UserService { get; set; }
		public IRolesService rolesService { get; set; }
		public void Test()
		{
			var t = UserService;
			var ts = rolesService;
		}
	}
}
