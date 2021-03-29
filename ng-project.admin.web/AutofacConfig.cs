using Autofac;
using ng_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ng_project.admin.web
{
	public class AutofacConfig : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var asmbly = Assembly.GetEntryAssembly();
			var assembly = Assembly.Load("ng-project");
			List<Type> types = new List<Type>();
			//foreach (Type type in assembly.GetTypes())
			//{
			//	if (type.GetCustomAttributes(typeof(ServiceAttribute), true).Length > 0)
			//	{

			//		builder.RegisterType(type).InstancePerLifetimeScope();
			//		types.Add(type);
			//	}
			//}IProjecTypeService
			builder.RegisterType<RolesService>().As<IRolesService>().InstancePerLifetimeScope();
			builder.RegisterType<ProjectSubTypeService>().As<IProjectSubTypeService>().InstancePerLifetimeScope();
			builder.RegisterType<ProjectTypeService>().As<IProjectTypeService>().InstancePerLifetimeScope();
			builder.RegisterType<SkillService>().As<ISkillService>().InstancePerLifetimeScope();
			builder.RegisterType<SubscriveService>().As<ISubscribeService>().InstancePerLifetimeScope();
			builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();
			builder.RegisterType<WorkerService>().As<IWorkerService>().InstancePerLifetimeScope();
			builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
			builder.RegisterType<NgMainService>().As<INgMainService>().InstancePerLifetimeScope();
		}
	}
}
