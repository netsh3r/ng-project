using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Models
{
	public class NewNewsModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile ImageDataLocal { get; set; }
		public int ProjectId { get; set; }
	}
}
