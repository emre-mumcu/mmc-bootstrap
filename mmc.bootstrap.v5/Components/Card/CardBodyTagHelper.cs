using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mmc.bootstrap.v5.Components.Card;

[HtmlTargetElement("mmc-card-body", ParentTag = "mmc-card")]
public class CardBodyTagHelper : TagHelper
{
	[HtmlAttributeName("title")]
	public string Title { get; set; } = string.Empty;

	[HtmlAttributeName("image")]
	public string Image { get; set; } = string.Empty;

	public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
	{
		output.TagName = "div";

		output.AddClass("card-body", HtmlEncoder.Default);		

        if(!string.IsNullOrEmpty(Image)) output.PreElement.AppendHtml(@$"<img src=""{Image}"" class=""card-img-top"" alt=""{Title}"">");

		output.PreContent.AppendHtml($@"<h5 class=""card-title"">{Title}</h5>");

		var content = (await output.GetChildContentAsync()).GetContent();

		output.Content.AppendHtml(content);
	}
}
