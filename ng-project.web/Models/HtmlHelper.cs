using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ng_project.web.Models
{
	public static class NgHtmlHelper
	{
        public static HtmlString HiddenForCollection<TModel, TProperty>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : ICollection
        {
			try
			{
    //            var model = html.ViewData.Model;
    //            var property = model != null
    //                        ? expression.Compile().Invoke(model)
    //                        : default(TProperty);

				//var result = new StringBuilder();
				//if(property != null && property.Count > 0)
				//{
				//	for(int i=0; i< property.Count; i++)
				//	{

				//	}
				//}
				//if (property != null && property.Count > 0)
				//{
				//    for (int i = 0; i < property.Count; i++)
				//    {
				//        var modelExp = expression.Parameters.First();
				//        var propertyExp = expression.Body;
				//        var itemExp = Expression.ArrayIndex(propertyExp, Expression.Constant(i));

				//        var itemExpression = Expression.Lambda<Func<TModel, object>>(itemExp, modelExp);

				//        result.AppendLine(html.HiddenFor(itemExpression).ToString());
				//    }
				//}

				//return new HtmlString(result.ToString());
				return null;
            }
            catch(Exception ex)
			{
                var t = ex.ToString();
                return null;
			}
            
        }
    }
}
