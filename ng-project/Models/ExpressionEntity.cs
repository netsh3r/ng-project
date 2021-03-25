using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Models
{
	public class ExpressionEntity
	{
		public void SetExpression<T,TProperty>(Expression<Func<T, TProperty>> expression) where T:Entity,new() where TProperty : Entity,new()
		{
			this.localExpression = expression;
			//this.ModelType = typeof(T);
			this.PropertyType = typeof(TProperty);
			this.Property = new TProperty();
		}
		private object localExpression;
		//public Type ModelType;
		public Type PropertyType;
		public object Property;
		public Expression<Func<T, TProperty>>  GetExpression<T, TProperty>()
		{
			return localExpression as Expression<Func<T, TProperty>>;
		}
	}
}


