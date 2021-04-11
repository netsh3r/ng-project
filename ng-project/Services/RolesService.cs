using ng_project.Entities;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	[Service]
	public class RolesService :MainService<Roles,int>, IRolesService
	{
		private static RolesService _instance;
		public static RolesService Instance
		{
			get
			{
				return _instance ?? (_instance = new RolesService());
			}
		}
	}
}
