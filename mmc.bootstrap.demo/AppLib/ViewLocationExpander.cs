using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace mmc.bootstrap.demo.AppLib;

public class ViewLocationExpander : IViewLocationExpander
{
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        //{2} is area, {1} is controller,{0} is the action
        string[] locations = new string[] {
            "/Content/{0}" + RazorViewEngine.ViewExtension,
            "/Content/Layout/{0}" + RazorViewEngine.ViewExtension,
            "/Content/Partials/{0}" + RazorViewEngine.ViewExtension,            
        };

        return locations.Union(viewLocations);
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    {
        context.Values["customviewlocation"] = nameof(ViewLocationExpander);
    }
}
