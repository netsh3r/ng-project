using Microsoft.EntityFrameworkCore;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Context
{
	public class NgContext : DbContext
	{
		public NgContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NgProjectDb;Trusted_Connection=True;");
		}
		//public DbSet<Email> Emails { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
 