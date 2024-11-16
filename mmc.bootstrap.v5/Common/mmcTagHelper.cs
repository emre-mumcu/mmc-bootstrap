using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mmc.bootstrap.v5.Common;

[HtmlTargetElement("mmc-style", TagStructure = TagStructure.NormalOrSelfClosing)]
public class mmcStyleTagHelper : TagHelper
{
    public string Version { get; set; } = null!;
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.Empty;

        output.TagMode = TagMode.SelfClosing;

        var linkBuilder = new TagBuilder("link");

        {
            linkBuilder.TagRenderMode = TagRenderMode.SelfClosing;

            linkBuilder.Attributes.Add("id", "theme");
            linkBuilder.Attributes.Add("rel", "stylesheet");
            linkBuilder.Attributes.Add("href", $"https://cdn.jsdelivr.net/npm/bootstrap@{Version}/dist/css/bootstrap.min.css");
            linkBuilder.Attributes.Add("crossorigin", "anonymous");  
        }             

        output.Content.AppendHtml(linkBuilder);
    }
}

[HtmlTargetElement("mmc-code", TagStructure = TagStructure.NormalOrSelfClosing)]
public class mmcCodeTagHelper : TagHelper
{
    public HighlightJsType Language { get; set; } = HighlightJsType.xml;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        string lang = Language.ToString().TrimStart('_').Replace("_", "-");
        
        output.TagName = string.Empty;
        output.PreElement.AppendHtml(@$"<pre><code class=""language-{lang}"">");
        output.PostElement.AppendHtml("</code></pre>");

        // Inner Content
        var innerContent = await output.GetChildContentAsync();
        output.Content.SetHtmlContent(innerContent.GetContent().Trim());
    }
}
