using ng_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ng_project.Entities
{
	public class Roles : Entity
	{
		public List<ProjectTypeRoles> ProjectTypeRoles { get; set; }
		[NotMapped]
		public List<ProjectType> ProjectType { get; set; }
		public string Name { get; set; }
		public List<RolesUser> RolesUsers { get; set; }
		private List<User> _User;
		[NotMapped]
		public List<User> Users
		{
			get
			{
				return RolesUsers.Select(t => new User()
				{ 
					Id = t.UsersId
				}).ToList();
			}
		}
		//public List<User> Users
		//{
		//	get
		//	{
		//		_User = RolesUsers?.Select(t => new User()
		//		{
		//			Id = t.UsersId
		//		}).ToList();
		//		return _User;
		//	}
		//	set
		//	{
		//		_User = value;
		//		RolesUsers = _User?.Select(t =>
		//		new RolesUser()
		//		{ 
		//			RolesId = Id,
		//			UsersId = t.Id
		//		}).ToList();
		//	}
		//}
	}
}
