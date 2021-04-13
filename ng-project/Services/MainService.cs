using ng_project.Entities;
using ng_project.EntityExpressions;
using ng_project.Managers;
using ng_project.Models;
using ng_project.SDK;
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
			EntityExpressions = new EntityExpression<T>();
		}
		private EntityExpression<T> EntityExpressions;
		public Expression<Func<T, object>> ExpressionObject;
		private EntityManager<T, IdT> entityManager { get; set; }
		public override T Find()
		{
			return entityManager.Find(EntityExpressions);
		}
		public override T Find(Func<T, bool> func)
		{
			return entityManager.Find(EntityExpressions, func);
		}
		public override IBaseService<T, IdT> Include(Expression<Func<T, object>> expression)
		{
			EntityExpressions.AddExpression(expression);
			return this;
		}
		public override int Add(T model)
		{
			return entityManager.Add(model);
		}
		public override void RemoveLink(object link)
		{
			entityManager.RemoveLink(link);
		}
		public override IBaseService<T, IdT> GetWithIncludes(Expression<Func<T, object>> expression)
		{
			ExpressionObject = expression;
			return this;
		}
		public override void Delete(int id)
		{
			entityManager.Delete(id);
		}
		public override T FindByFuncWithInclude(Func<object, bool> func)
		{
			//return entityManager.Find(ExpressionObject, func);
			return entityManager.Find(EntityExpressions);
		}
		public override ICollection<T> FindAllWithIncude(Func<object, bool> func)
		{
			return entityManager.FindAll(ExpressionObject, func);
		}
		public override ICollection<T> FindAll()
		{
			if(EntityExpressions.ExpressionList.Count>0)
			{
				return entityManager.FindAll(EntityExpressions);
			}
			return entityManager.FindAll();
		}

		public override ICollection<T> FindAll(Func<T, bool> func)
		{
			if (EntityExpressions.ExpressionList.Count > 0)
			{
				return entityManager.FindAll(EntityExpressions, func);
			}
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
