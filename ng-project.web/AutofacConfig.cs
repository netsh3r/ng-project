using Autofac;
using Autofac.Extensions.DependencyInjection;
using ng_project.SDK;
using ng_project.Services;
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
			var assembly = Assembly.Load("ng-project");
			List<Type> types = new List<Type>();
			foreach (Type type in assembly.GetTypes())
			{
				if (type.GetCustomAttributes(typeof(ServiceAttribute), true).Length > 0)
				{

					builder.RegisterType(type).InstancePerLifetimeScope();
					types.Add(type);
				}
			}
			builder.RegisterType<SomeModel>().As<ISomeModel>().InstancePerLifetimeScope();
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