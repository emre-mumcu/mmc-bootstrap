using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Contexts;

namespace mmc.bootstrap.v5.Components.Accordion;

[HtmlTargetElement("accordion-item", TagStructure = TagStructure.NormalOrSelfClosing)]
[HtmlTargetElement(ParentTag = "accordion")]
public class AccordionItemTagHelper : TagHelper
{
    public string Title { get; set; } = null!;
    public bool Show { get; set; } = false;
    public bool Code { get; set; } = false;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // var curContent = output.IsContentModified ? output.Content : await output.GetChildContentAsync();

        var accotdionContext = context.Items[typeof(AccordionContext)] as AccordionContext;

        if (accotdionContext == null) throw new ArgumentException("AccordionContext is not specified in context parameter");

        // var accordionId = context.Items["AccordionId"];

        var accordionId = accotdionContext.Id;

       string guidStr = Guid.NewGuid().ToString();

        output.TagName = "div";

        output.TagMode = TagMode.StartTagAndEndTag;

        output.PreElement.AppendHtml(@"
			<div class=""accordion-item"">"
        );

        output.PreElement.AppendHtml(@$"
			<h2 class=""accordion-header"">
				<button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#{guidStr}"">{Title}</button>
			</h2>"
        );

        output.PreElement.AppendHtml(@$"
			<div id=""{guidStr}"" class=""accordion-collapse collapse {(Show ? ("show") : (""))}"" data-bs-parent=""#{accordionId}"">
				<div class=""accordion-body"">"
        );

        // Inner Content
        var innerContent = await output.GetChildContentAsync();
        output.Content.SetHtmlContent(innerContent.GetContent().Trim());

        if (Code)
        {
            output.PreContent.SetHtmlContent("<pre><code>");
            output.PostContent.SetHtmlContent("</code></pre>");
        }

        output.PostElement.AppendHtml("</div></div></div>");
    }
}
