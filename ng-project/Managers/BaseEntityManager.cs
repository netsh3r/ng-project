using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Managers
{
	//</ineritdoc>
	public abstract class BaseEntityManager<T, IdT> : IBaseEntityManager<T, IdT>
	{
		//</ineritdoc>
		public abstract void Add(T entity);
		//</ineritdoc>
		public abstract void Delete(IdT id);
		//</ineritdoc>
		public abstract void Edit(T entity);
		//</ineritdoc>
		public abstract ICollection<T> FindAll();
		//</ineritdoc>
		public abstract T FindById(IdT id);
	}
}
