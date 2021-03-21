using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.Web.React.Controllers
{
	public class TestController : Controller
	{
		[Route("comments")]
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public string Index()
		{
			return "123123";
		}
	}
}
