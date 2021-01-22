using Microsoft.EntityFrameworkCore;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Context
{
	public class Ng_context : DbContext
	{
		public Ng_context()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=efbasicsappdb;Trusted_Connection=True;");
		}
	}
}
 