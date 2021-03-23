using Microsoft.EntityFrameworkCore;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Context
{
	public class NgContext : DbContext
	{
		public DbSet<SkillsParticipant> SkillsParticipants { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<NewsImage> NewsImages { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<Participant> Participants { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<ProjectImage> ProjectImages { get; set; }
		public DbSet<MainProjectImage> MainProjectImages { get; set; }

		//public NgContext()
		//{
		//	Database.EnsureDeleted();   // удаляем бд со старой схемой
		//	Database.EnsureCreated();   // создаем бд с новой схемой
		//}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
			   //.UseLazyLoadingProxies()
			   .UseSqlServer(@"Server=DESKTOP-BO6C3SK;Initial Catalog=ng_project;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProjectParticipant>()
				.HasOne(t => t.Project)
				.WithMany(t => t.ProjectParticipant)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
 