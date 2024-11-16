using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mmc.bootstrap.demo.AppLib;

[HtmlTargetElement("mso", TagStructure = TagStructure.NormalOrSelfClosing)]
public class MaterialSymbolOutlinedTagHelper: TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.Empty;
        output.TagMode = TagMode.StartTagAndEndTag;

        var spanBuilder = new TagBuilder("span");
        spanBuilder.AddCssClass("material-symbols-outlined");
        var innerContent = await output.GetChildContentAsync();
        spanBuilder.InnerHtml.Append(innerContent.GetContent().Trim());

        output.Content.AppendHtml(spanBuilder);
    }
}

[HtmlTargetElement("msr", TagStructure = TagStructure.NormalOrSelfClosing)]
public class MaterialSymbolRoundedTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.Empty;
        output.TagMode = TagMode.StartTagAndEndTag;

        var spanBuilder = new TagBuilder("span");
        spanBuilder.AddCssClass("material-symbols-rounded");
        var innerContent = await output.GetChildContentAsync();
        spanBuilder.InnerHtml.Append(innerContent.GetContent().Trim());

        output.Content.AppendHtml(spanBuilder);
    }
}

[HtmlTargetElement("mss", TagStructure = TagStructure.NormalOrSelfClosing)]
public class MaterialSymbolSharpTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.Empty;
        output.TagMode = TagMode.StartTagAndEndTag;

        var spanBuilder = new TagBuilder("span");
        spanBuilder.AddCssClass("material-symbols-sharp");
        var innerContent = await output.GetChildContentAsync();
        spanBuilder.InnerHtml.Append(innerContent.GetContent().Trim());

        output.Content.AppendHtml(spanBuilder);
    }
}

//<span class="material-symbols-outlined">description</span>
// const iconStyles = ["Filled", "Outlined", "Rounded", "TwoTone", "Sharp"];
//<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet" />