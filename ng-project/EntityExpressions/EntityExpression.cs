using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.EntityExpressions
{
	public class EntityExpression<T> where T: Entity
	{
		public List<Expression<Func<T, object>>> ExpressionList { get; set; } = new List<Expression<Func<T, object>>>();
		public void AddExpression(Expression<Func<T, object>> express)
		{
			ExpressionList.Add(express);
		}
	}
}
