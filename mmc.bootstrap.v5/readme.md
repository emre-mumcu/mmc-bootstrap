dotnet add reference ..\mmc.toolkit\mmc.toolkit.csproj




// https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-9.0
// https://techyian.github.io/2020-03-02-aspnetcore-breadcrumbs/
// https://github.com/techyian/SuperSimpleBreadcrumbs/tree/main/SuperSimpleBreadcrumbs
// https://stackoverflow.com/questions/30696337/unable-to-utilize-urlhelper
// https://stackoverflow.com/questions/54839292/unable-to-resolve-service-for-type-microsoft-aspnetcore-mvc-iurlhelper-while-a




// inject ViewContext in tag helper (must be public)
[ViewContext, HtmlAttributeNotBound] public ViewContext VContext { get; set; } = null!;





private readonly IUrlHelperFactory UHF;
private readonly IActionContextAccessor ACA;
public BreadcrumbTagHelper(IUrlHelperFactory uhf, IActionContextAccessor aca)
{
    UHF = uhf;
    ACA = aca;
}
var urlHelper = UHF.GetUrlHelper(ACA.ActionContext);
var url = urlHelper.Action(item.Action, item.Controller);
// or
var urlHelper = VContext?.HttpContext.Items.Values.OfType<IUrlHelper>().FirstOrDefault();
urlHelper.Action("", "");



Array.Empty<string>(); // Enumerable.Empty<string>()
