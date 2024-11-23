// dotnet add reference ..\mmc.bootstrap.v5\mmc.bootstrap.v5.csproj
// dotnet add reference ..\mmc.toolkit\mmc.toolkit.csproj
// dotnet add reference ..\mmc.web\mmc.web.csproj

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using mmc.bootstrap.demo.AppLib;
using mmc.web.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.Configure<RazorViewEngineOptions>(options => {
	options.ViewLocationExpanders.Add(new ViewLocationExpander( ["/Content", "/Content/Partials"] ));
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddSingleton<MockDataProvider>();

/* 
    builder.Services.AddScoped<IUrlHelper>(x =>
    {
        var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
        var factory = x.GetRequiredService<IUrlHelperFactory>();
        return factory.GetUrlHelper(actionContext);
    }); 
*/

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();