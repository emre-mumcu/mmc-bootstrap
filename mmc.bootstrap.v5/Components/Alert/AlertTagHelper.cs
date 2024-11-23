using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Common;

namespace mmc.bootstrap.v5.Components.Alert;

[HtmlTargetElement("mmc-alert")]
public class AlertTagHelper : TagHelper
{
    public Variant Variant { get; set; } = Variant.primary;

    public bool Dismissable { get; set; } = true;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var content = (await output.GetChildContentAsync()).GetContent();

        output.TagName = "div";

        output.Attributes.Add("role", "alert");

        output.AddClass("alert", HtmlEncoder.Default);

        output.AddClass($"alert-{Variant}", HtmlEncoder.Default);

        if (Dismissable)
        {
            output.AddClass("alert-dismissible", HtmlEncoder.Default);
            output.AddClass("fade", HtmlEncoder.Default);
            output.AddClass("show", HtmlEncoder.Default);

            var btnTagbuilder = new TagBuilder("button");
            btnTagbuilder.AddCssClass("btn-close");
            btnTagbuilder.Attributes.Add("data-bs-dismiss", "alert");
            btnTagbuilder.Attributes.Add("aria-label", "Close");

            output.Content.AppendHtml(content);
            output.Content.AppendHtml(btnTagbuilder);
        }
        else
        {
            output.Content.AppendHtml(content);
        }
    }
}