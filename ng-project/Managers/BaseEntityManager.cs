using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Managers
{
	//</ineritdoc>
	public abstract class BaseEntityManager<T, IdT> : IBaseEntityManager<T, IdT>
	{
		public abstract ICollection<T> FindAll(Expression<Func<T, object>> expression);
		//</inheritdoc>
		public abstract ICollection<T> FindAll(Func<T, bool> expression);
		//</ineritdoc>
		public abstract void Add(T entity);
		//</ineritdoc>
		public abstract void Delete(IdT id);
		//</ineritdoc>
		public abstract void Save(T entity);
		//</ineritdoc>
		public abstract ICollection<T> FindAll();
		//</ineritdoc>
		public abstract T FindById(IdT id);
		//</inheritdoc>
		public abstract T Find(Func<T, bool> expression);
	}
}
