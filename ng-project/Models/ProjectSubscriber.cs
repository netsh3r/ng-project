using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Models
{
	public class ProjectSubscriber
	{
		public Project Projects { get; set; }
		public int? ProjectsId { get; set; }
		public Subscriber Subscribers { get; set; }
		public int? SubscribersId { get; set; }
	}
}
