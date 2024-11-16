using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mmc.bootstrap.v5.Components.Navbar;

[HtmlTargetElement("navbar", TagStructure = TagStructure.NormalOrSelfClosing)]
[RestrictChildren("ul", "form")]
public class NavbarTagHelper : TagHelper
{
    public string? Title { get; set; }
    public string guid { get; set; }

    public NavbarTagHelper()
    {
        guid = Guid.NewGuid().ToString();
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.Empty;

        var navbarTagBuilder = new TagBuilder("nav");
        {
            navbarTagBuilder.AddCssClass("navbar");
            navbarTagBuilder.AddCssClass("navbar-expand-lg");
            navbarTagBuilder.AddCssClass("bg-body-tertiary");
        }

        var navbarContainer = new TagBuilder("div");
        {
            navbarContainer.AddCssClass("container-fluid");
        }

        var navbarBrand = new TagBuilder("a");
        {
            navbarBrand.AddCssClass("navbar-brand");
            navbarBrand.Attributes.Add("href", "#");
            navbarBrand.InnerHtml.Append($"{Title}");
        }

        var navbarCloseButton = new TagBuilder("button");
        {
            navbarCloseButton.AddCssClass("navbar-toggler");
            navbarCloseButton.Attributes.Add("data-bs-toggle", "collapse");
            navbarCloseButton.Attributes.Add("data-bs-target", $"#{guid}");
            navbarCloseButton.Attributes.Add("aria-controls", $"{guid}");
            navbarCloseButton.Attributes.Add("aria-expanded", "false");
            navbarCloseButton.Attributes.Add("aria-label", "Toggle navigation");
        }

        var navbarCloseButtonContent = new TagBuilder("span");
        {
            navbarCloseButtonContent.AddCssClass("navbar-toggler-icon");
            navbarCloseButton.InnerHtml.AppendHtml(navbarCloseButtonContent);
        }

        var navbarContent = new TagBuilder("div");
        {
            navbarContent.AddCssClass("collapse");
            navbarContent.AddCssClass("navbar-collapse");
            navbarContent.Attributes.Add("id", $"{guid}");
            navbarContent.InnerHtml.AppendHtml((await output.GetChildContentAsync()).GetContent());
        }

        navbarContainer.InnerHtml.AppendHtml(navbarBrand);
        navbarContainer.InnerHtml.AppendHtml(navbarCloseButton);
        navbarContainer.InnerHtml.AppendHtml(navbarContent);
        navbarTagBuilder.InnerHtml.AppendHtml(navbarContainer);

        output.Content.AppendHtml(navbarTagBuilder);
    }
}