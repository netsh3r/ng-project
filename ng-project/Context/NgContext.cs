using Microsoft.EntityFrameworkCore;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Context
{
	public class NgContext : DbContext
	{
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
			//Database.EnsureDeleted();   // удаляем бд со старой схемой
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder
			   .UseSqlServer(@"Server=DESKTOP-BO6C3SK;Initial Catalog=ng_project;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Subscriber>().HasData(new Subscriber { Id = 1, UserId = 1 });
			//modelBuilder.Entity<Subscriber>().HasData(new Subscriber { Id = 2, UserId = 2 });
			//modelBuilder.Entity<Subscriber>().HasData(new Subscriber { Id = 3, UserId = 3 });
			//modelBuilder.Entity<Subscriber>().HasData(new Subscriber { Id = 4, UserId = 4 });

			//modelBuilder.Entity<Worker>().HasData(new Worker { Id = 1, UserId =1 });
			//modelBuilder.Entity<Worker>().HasData(new Worker { Id = 2, UserId = 2 });
			//modelBuilder.Entity<Worker>().HasData(new Worker { Id = 3, UserId = 3 });
			//modelBuilder.Entity<Worker>().HasData(new Worker { Id = 4, UserId = 4 });

			

			//modelBuilder.Entity<User>().HasData(new User { Id = 1, login = "admin", Password = "123" });
			//modelBuilder.Entity<User>().HasData(new User { Id = 2, login = "admin2", Password = "123" });
			//modelBuilder.Entity<User>().HasData(new User { Id = 3, login = "admin3", Password = "123" });
			//modelBuilder.Entity<User>().HasData(new User { Id = 4, login = "admin4", Password = "123" });
		}
	}
}
 