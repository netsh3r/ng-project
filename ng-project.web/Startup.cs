using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ng_project.web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			services.AddMvc().AddControllersAsServices();
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
			{ 
				options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
			});
			services.AddMemoryCache();
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new AutofacConfig());
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			var option = new RewriteOptions()
				.AddRedirect("(.*)/$", "$2");
			app.UseRewriter(option);
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			//app.UseStatusCodePages();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			
			app.UseAuthentication(); 
			app.UseAuthorization();
			app.UseCookiePolicy();
			//app.UseToken();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
