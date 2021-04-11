using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// 
	/// </summary>
	public class SenderNotify : Entity
	{
		public User User { get; set; }
		public int UserId { get; set; }
		public Notify Notify { get; set; }
		public int NotifyId { get; set; }
	}
}
