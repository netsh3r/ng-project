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
			//foreach (var a in asmbly.GetReferencedAssemblies())
			//{
			var assembly = Assembly.Load("ng-project");
			//foreach (var type in assemply.GetTypes().Where(t => t.GetCustomAttributes(typeof(ServiceAttribute), true).Length > 0).ToList())
			//{
			//	var t = type;
			//}
			List<Type> types = new List<Type>();
			foreach (Type type in assembly.GetTypes())
			{
				if (type.GetCustomAttributes(typeof(ServiceAttribute), true).Length > 0)
				{

					builder.RegisterType(type).InstancePerLifetimeScope();
					types.Add(type);
				}
					
			}
			//}
			//foreach(Type t in types)
			//{
			//	builder.RegisterType<SomeModel>().As<t.BaseType>().InstancePerLifetimeScope();
			//}
			builder.RegisterType<SomeModel>().As<ISomeModel>().InstancePerLifetimeScope();
		}
	}
}
