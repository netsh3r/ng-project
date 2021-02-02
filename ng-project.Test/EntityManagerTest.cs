using ng_project.Entities;
using ng_project.Managers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Test
{
	[TestFixture]
	public class EntityManagerTest
	{
		private EntityManager<T,IdT> GetEntityManager<T, IdT>() where T:Entity<IdT>, new()
		{
			return new EntityManager<T, IdT>();
		}
		[Test]
		public void GetUserManager()
		{
			var manager = UserManager.Instance;
			Assert.IsNotNull(manager);
		}

		[Test]
		public void GetManager()
		{
			var manager = GetEntityManager<User, int>();
			Assert.IsNotNull(manager);
		}
		[Test]
		public void AddUser()
		{
			var manager = GetEntityManager<User, int>();
			try
			{
				var count = manager.FindAll().Count;
				manager.Add(new User() { LastName="123" });
				Assert.AreEqual(manager.FindAll().Count, count+1);
			}
			catch(Exception ex)
			{
				Assert.Fail();
			}
		}
		[Test]
		public void DeleteUser()
		{
			var manager = GetEntityManager<User, int>();
			try
			{
				var count = manager.FindAll().Count;
				manager.Delete(1);
				Assert.AreEqual(manager.FindAll().Count, count - 1);
			}
			catch (Exception ex)
			{
				Assert.Fail();
			}
		}
		[Test]
		public void FindAllUser()
		{
			var manager = GetEntityManager<User, int>();
			Assert.AreEqual(manager.FindAll().Count, 1);
		}

		[Test]
		public void FindUserById()
		{
			var manager = GetEntityManager<User, int>();
			try
			{

				Assert.IsNotNull(manager.FindById(1));
			}
			catch(Exception ex)
			{
				Assert.Fail();
			}
		}
	}
}
