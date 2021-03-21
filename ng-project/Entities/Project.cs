using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Entities
{
	public class Project : Entity<int>
	{
		public MainProjectImage MainProjectImage { get; set; }
		[NotMapped]
		public IFormFile MainImageDataLocal { get; set; }
		public ProjectImage ProjectImage { get; set; }
		[NotMapped]
		public IFormFile ImageDataLocal { get; set; }
		[Display(Name="Название проекта")]
		public string Name { get; set; }
		[Display(Name="Полное описание проекта")]
		public string Description { get; set; }
		[Display(Name="Краткое описание проекта")]
		public string ShortDescription { get; set; }
		public User User { get; set; }
		public int UserId { get; set; }
		public List<News> News { get; set; }
		public List<ProjectParticipant> ProjectParticipant { get; set; } = new List<ProjectParticipant>();
	}
}
