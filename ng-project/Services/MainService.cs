using ng_project.Entities;
using ng_project.Managers;
using ng_project.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	public abstract class MainService<T, IdT> : BaseService<T, IdT> where T : Entity, new()
	{
		public MainService(){
			this.entityManager = EntityManager<T, IdT>.Instance;
		}
		public Expression<Func<T, object>> ExpressionObject;
		public override int Add(T model)
		{
			return entityManager.Add(model);
		}
		public override void RemoveLink(object link)
		{
			entityManager.RemoveLink(link);
		}
		public override IBaseService<T, IdT> GetWithInclude(Expression<Func<T, object>> expression)
		{
			ExpressionObject = expression;
			return this;
		}
		private EntityManager<T, IdT> entityManager { get; set; }
		public override void Delete(int id)
		{
			entityManager.Delete(id);
		}
		public override T FindByFuncWithInclude(Func<object, bool> func)
		{
			return entityManager.Find(ExpressionObject, func);
		}
		public override ICollection<T> FindAllWithIncude(Func<object, bool> func)
		{
			return entityManager.FindAll(ExpressionObject, func);
		}
		public override ICollection<T> FindAll()
		{
			if(ExpressionObject != null)
			{
				return FindAll(ExpressionObject);
			}
			return entityManager.FindAll();
		}

		public override ICollection<T> FindAll(Func<T, bool> func)
		{
			return entityManager.FindAll(func);
		}
		
		public override T FindByFunc(Func<T, bool> func)
		{
			return entityManager.Find(func);
		}

		public override T FindById(int id)
		{
			return entityManager.FindById(id);
		}
		public override ICollection<T> FindAll(Expression<Func<T, object>> expression)
		{
			return entityManager.FindAll(expression);
		}

		public override void Save(T model)
		{
			entityManager.Save(model);
		}
	}
}
