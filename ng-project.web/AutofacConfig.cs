using Autofac;
using Autofac.Extensions.DependencyInjection;
using ng_project.SDK;
using ng_project.Services;
using ng_project.web.Components;
using ng_project.web.Controllers;
using ng_project.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ng_project.web
{
	public class AutofacConfig : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var asmbly = Assembly.GetEntryAssembly();
			var asseblyServ = Assembly.Load("ng-project");
			var assembly = Assembly.Load("ng-project.Web");
			List<Type> types = new List<Type>();
			foreach(Type type in assembly.GetTypes())
			{
				if (type.FullName.Contains("Controller"))
				{
					builder.RegisterType(type).PropertiesAutowired();
				}
			}
			foreach(Type type in asseblyServ.GetTypes())
			{
				if (type.GetCustomAttributes(typeof(ServiceAttribute), true).Length > 0)
				{
					var t = type.GetInterfaces().Last();
					builder.RegisterType(type).As(t).SingleInstance();
				}
			}
		}
	}
}

public class us1 { 
	public int id { get; set; }
	private int id2 { get; set; }
}

public class us2 : us1
{

}