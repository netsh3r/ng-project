using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Middlewares
{
	public static class TokenExtension
	{
		public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<TokenMiddleware>();
		}
	}
}
