using Autofac;
using Autofac.Extensions.DependencyInjection;
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
			builder.RegisterType<NewsService>().As<INewsService>().InstancePerLifetimeScope();
			builder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();
			builder.RegisterType<RolesService>().As<IRolesService>().InstancePerLifetimeScope();
			builder.RegisterType<ProjectSubTypeService>().As<IProjectSubTypeService>().InstancePerLifetimeScope();
			builder.RegisterType<ProjectTypeService>().As<IProjectTypeService>().InstancePerLifetimeScope();
			builder.RegisterType<SkillService>().As<ISkillService>().InstancePerLifetimeScope();
			builder.RegisterType<SubscriveService>().As<ISubscribeService>().InstancePerLifetimeScope();
			builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();
			builder.RegisterType<WorkerService>().As<IWorkerService>().InstancePerLifetimeScope();
			//builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
			builder.RegisterType<NgMainService>().As<INgMainService>().InstancePerLifetimeScope();
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