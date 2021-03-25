﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	public abstract class BaseService<T, IdT> : IBaseService<T, IdT>
	{
		public abstract ICollection<T> FindAll();

		public abstract ICollection<T> FindAll(Func<T, bool> func);

		public abstract ICollection<T> FindAll(Expression<Func<T, object>> expression);

		public abstract T FindByFunc(Func<T, bool> func);

		public abstract T FindById(IdT id);

		public abstract IBaseService<T, IdT> GetWithInclude(Expression<Func<T, object>> expression);

		public abstract void Save(T model);
	}
}