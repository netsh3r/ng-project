using ng_project.Entities;
using ng_project.Managers;
using ng_project.Models;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	[Service]
	public class WorkerService : MainService<Worker,int>, IWorkerService
	{
		public WorkerService()
		{
			WorkerManager = WorkerManager.Instance;
		}
		private WorkerManager WorkerManager;
		public List<Worker> GetAll()
		{
			return WorkerManager.FindAll().ToList();
		}

		//public override IBaseService<Worker,int> GetWithIncludes(Expression<Func<Worker, object>> expression)
		//{
		//	base.ExpressionObject= expression;
		//	return this;
		//}

		//public override ICollection<Worker> FindAll(List<Expression> expression)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
