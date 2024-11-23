using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Common;

namespace mmc.bootstrap.v5.Components.Button;

[HtmlTargetElement("mmc-button")]
public class ButtonTagHelper : TagHelper
{
    // [HtmlAttributeName("bs-variant")]
    public Variant Variant { get; set; } = Variant.primary;
    public ButtonType Type { get; set; } = ButtonType.Button;
    public string? Value { get; set; }
    public bool Disabled { get; set; }
    public Size Size { get; set; } = Size.Normal;
    public bool Outline { get; set; }
    public bool Block { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "button";

        output.Attributes.Add("type", Type.ToString().ToLowerInvariant());

        output.AddClass("btn", HtmlEncoder.Default);

        output.AddClass($"btn-{(Outline?"outline-":"")}{Variant}", HtmlEncoder.Default);

        output.Attributes.Add("role", "button");

        if (!string.IsNullOrEmpty(Value))
        {
            output.Attributes.Add("value", Value);
        }

        if (Disabled)
        {
            output.Attributes.Add(new TagHelperAttribute("disabled"));
        }

        if (Size != Size.Normal)
        {
            output.AddClass(Size switch
            {
                Size.Large => "btn-lg",
                Size.Small => "btn-sm",
                Size.Normal => "",
                _ => throw new ArgumentOutOfRangeException(nameof(Size))
            }, HtmlEncoder.Default);
        }

        if (Block)
        {
            output.AddClass("btn-block", HtmlEncoder.Default);
        }

        var content = await output.GetChildContentAsync();
        {
            if (content.IsEmptyOrWhiteSpace)
            {
                output.TagMode = TagMode.SelfClosing;
            }
            else
            {
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content = content;
            }
        }
    }
}