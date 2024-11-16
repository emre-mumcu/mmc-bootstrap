// dotnet add reference ..\mmc.bootstrap.v5\mmc.bootstrap.v5.csproj

using Microsoft.AspNetCore.Mvc.Infrastructure;
using mmc.bootstrap.demo.AppLib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(options => { options.ViewLocationExpanders.Add(new ViewLocationExpander()); });

/* 
    builder.Services.Configure<mmcTagHelperOptions>(options =>
    {
        options.GeneralDateFormatter = d => string.Format("{0:d}", d);
    }); 
*/

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

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

