using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.EntityExpression
{
	public class WorkerExpression
	{
		public static Func<object,bool> FindByUserId(int userId)
		{
			return s => (s as Worker).UserId == userId;
		}
		public static Expression<Func<Worker,object>> UserWorker()
		{
			return t => new Worker()
			{
				Projects = t.Projects,
				Id = t.Id,
				Skills = t.Skills,
				UserId = t.UserId
			};
		}
	}
}
