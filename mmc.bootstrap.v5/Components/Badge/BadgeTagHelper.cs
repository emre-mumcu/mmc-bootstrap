using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Common;

namespace mmc.bootstrap.v5.Components.Badge;

[HtmlTargetElement("mmc-badge", TagStructure = TagStructure.NormalOrSelfClosing)]
public class BadgeTagHelper : TagHelper
{
    public Variant Variant { get; set; } = Variant.primary;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.Empty;

        output.TagMode = TagMode.StartTagAndEndTag;

        var spanBuilder = new TagBuilder("span");
        {
            spanBuilder.AddCssClass("badge");
            spanBuilder.AddCssClass($"text-bg-{Variant}");
        }
        
        spanBuilder.InnerHtml.Append((await output.GetChildContentAsync()).GetContent().Trim());

        output.Content.AppendHtml(spanBuilder);
    }
}