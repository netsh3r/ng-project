﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Middlewares
{
	public class TokenMiddleware
	{
		private readonly RequestDelegate _next;
		public TokenMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var token = context.Request.Query["Token"];
			if (token != "123")
			{
				context.Response.StatusCode = 403;
				await context.Response.WriteAsync("Token is invalid");
			}
			else
			{
				await _next.Invoke(context);
			}
		}
	}
}
