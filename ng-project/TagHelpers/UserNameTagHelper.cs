using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.TagHelpers
{
	
	public class UserNameTagHelper :TagHelper
	{
		public string Name { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "span";
			output.Content.SetContent($"Здравствуйте ");
		}
	}
}
