using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Contexts;

namespace mmc.bootstrap.v5.Components.Accordion;

[HtmlTargetElement("accordion", TagStructure = TagStructure.NormalOrSelfClosing)]
[RestrictChildren("accordion-item")]
public class AccordionTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string? accordionId = output.Attributes.FirstOrDefault(attribute => attribute.Name == "id")
            ?.Value?.ToString()
            ?? Guid.NewGuid().ToString()
        ;

        // context.Items.Add(typeof(AccordionContext), new AccordionContext() { Id = accordionId });
        context.Items[typeof(AccordionContext)] = new AccordionContext() { Id = accordionId };        

        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.AddClass("accordion", HtmlEncoder.Default);
    }
}
