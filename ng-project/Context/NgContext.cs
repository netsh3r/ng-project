using Microsoft.EntityFrameworkCore;
using ng_project.Entities;
using ng_project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Context
{
	public class NgContext : DbContext
	{
		public DbSet<ProjectSubscriber> ProjectSubscriber { get; set; }
		public DbSet<Roles> Roles { get; set; }
		public DbSet<ProjectSubType> ProjectSubTypes { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Creator> Creators { get; set; }
		public DbSet<Worker> Participants { get; set; }
		public DbSet<Subscriber> Subscribers { get; set; }
		public DbSet<Teg> Tegs { get; set; }
		public DbSet<ProjectType> ProjectTypes { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<NewsImage> NewsImages { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<ProjectImage> ProjectImages { get; set; }
		public DbSet<MainProjectImage> MainProjectImages { get; set; }

		public NgContext()
		{
			Database.EnsureDeleted();   // удаляем бд со старой схемой
										//Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder
			   .UseSqlServer(@"Server=DESKTOP-BO6C3SK;Initial Catalog=ng_project;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProjectTypeRoles>()
				.HasKey(s => new { s.ProjectTypeId, s.RolesId });
			modelBuilder.Entity<ProjectTypeRoles>()
				.HasOne(ps => ps.Roles)
				.WithMany(s => s.ProjectTypeRoles)
				.HasForeignKey(c => c.RolesId);
			modelBuilder.Entity<ProjectTypeRoles>()
				.HasOne(t => t.ProjectType)
				.WithMany(ts => ts.ProjectTypesRoles)
				.HasForeignKey(s => s.ProjectTypeId);

			modelBuilder.Entity<ProjectSubscriber>()
				.HasKey(s => new { s.ProjectsId, s.SubscribersId });
			modelBuilder.Entity<ProjectSubscriber>()
				.HasOne(ps => ps.Subscribers)
				.WithMany(p => p.ProjectSubscribers)
				.HasForeignKey(t => t.SubscribersId);
			modelBuilder.Entity<ProjectSubscriber>()
				.HasOne(t => t.Projects)
				.WithMany(s => s.ProjectSubscribers)
				.HasForeignKey(c => c.ProjectsId);

			modelBuilder.Entity<RolesUser>()
				.HasKey(s => new { s.RolesId, s.UsersId});
			modelBuilder.Entity<RolesUser>()
				.HasOne(ps => ps.Roles)
				.WithMany(p => p.RolesUsers)
				.HasForeignKey(t => t.RolesId);
			modelBuilder.Entity<RolesUser>()
				.HasOne(t => t.Users)
				.WithMany(s => s.RolesUsers)
				.HasForeignKey(c => c.UsersId);
		}
	}
}
 