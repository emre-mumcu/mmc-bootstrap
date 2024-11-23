using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mmc.bootstrap.v5.Components.Breadcrumb;

[HtmlTargetElement("mmc-breadcrumb", TagStructure = TagStructure.NormalOrSelfClosing)]
public class BreadcrumbTagHelper : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext VContext { get; set; } = null!;

    protected HttpRequest? Request => VContext?.HttpContext.Request;

    protected IServiceProvider? ServiceProvider => VContext?.HttpContext.RequestServices;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (VContext != null)
        {
            // var urlHelper = VContext?.HttpContext.Items.Values.OfType<IUrlHelper>().FirstOrDefault(); urlHelper.Action("", "");

            output.TagName = "ol";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "breadcrumb");

            var homeItemBuilder = new TagBuilder("li");
            {
                homeItemBuilder.AddCssClass("breadcrumb-item");
                homeItemBuilder.AddCssClass("active");
                homeItemBuilder.InnerHtml.AppendHtml(@$"
                    <a class=""text-decoration-none"" href=""#"">
                        <span class=""material-symbols-outlined"">home</span>Home
                    </a>");

                // output.Content.AppendHtml(homeItemBuilder);
            }

            string[] pathSplit = VContext.HttpContext.Request.Path.Value?.Split("/") ?? Array.Empty<string>();

            foreach (var path in pathSplit)
            {
                output.Content.AppendHtml(CreateItem(path));
            }

            var v = GetCurrentRouterUrl();
        }
        else
        {
            output.Content.AppendHtml("<span>Viewcontext is NULL. Plase set VContext to create breadcrumb.</span>");
        }
    }

    private string CreateItem(string Text, string? Link = null)
    {
        if (string.IsNullOrEmpty(Link))
            return @$"<li class=""breadcrumb-item active"">{Text}</li>";
        else
            return @$"<li class=""breadcrumb-item active"">
                <a class=""text-decoration-none"" href=""{Link}"">Home</a>
            </li>";
    }

    private (string? action, string? url) GetCurrentRouterUrl()
    {
        var routeValues = VContext?.ActionDescriptor.RouteValues;

        if (routeValues is null) return (null, null);

        if (routeValues.TryGetValue("action", out var action))
        {
            var urlHelper = VContext?.HttpContext.Items.Values.OfType<IUrlHelper>().FirstOrDefault();
            if (urlHelper == null) return (null, null);
            else return (action, urlHelper.Action(action));
        }

        if (routeValues.TryGetValue("page", out var page))
        {
            return (page, page);
        }

        return (null, null);
    }
}