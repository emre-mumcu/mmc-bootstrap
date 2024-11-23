using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Contexts;

namespace mmc.bootstrap.v5.Components.Card;

[HtmlTargetElement("mmc-card")]
[RestrictChildren("mmc-card-body")]
public class CardTagHelper : TagHelper
{
	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		string? cardId = output.Attributes.FirstOrDefault(attribute => attribute.Name == "id")
			?.Value?.ToString()
			?? Guid.NewGuid().ToString()
		;

		// context.Items.Add(typeof(CardContext), new CardContext() { Id = accordionId });
		context.Items[typeof(CardContext)] = new CardContext() { Id = cardId };

		output.TagName = "div";
		output.TagMode = TagMode.StartTagAndEndTag;
		output.AddClass("card", HtmlEncoder.Default);
	}
}
