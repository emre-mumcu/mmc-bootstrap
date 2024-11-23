
dotnet add reference ..\mmc.toolkit\mmc.toolkit.csproj



https://jsonplaceholder.typicode.com/
https://dummyjson.com/
https://mocki.io/fake-json-api
https://randomuser.me/api/
https://dummyuser.vercel.app/users
https://dummyimage.com/



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


// https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-8.0
// https://github.com/aspnet/Mvc/blob/release/2.2/src/Microsoft.AspNetCore.Mvc.TagHelpers/TagHelperOutputExtensions.cs#L166