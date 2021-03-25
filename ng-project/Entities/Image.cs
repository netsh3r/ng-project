using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ng_project.Entities
{
	public class ImageBase : Entity
	{
		[Display(Name = "Изображение")]
		public byte[] Data { get; set; }
	}
	public class Image : ImageBase
	{
		public User User { get; set; }
		public int UserId { get; set; }
		
	}

	public class NewsImage :ImageBase
	{
		public News News { get; set; }
		public int NewsId { get; set; }
	}

	public class ProjectImage : ImageBase
	{
		public Project Project { get; set; }
		public int ProjectId { get; set; }
	}
	public class MainProjectImage : ImageBase
	{
		public Project Project { get; set; }
		public int ProjectId { get; set; }
	}
}
