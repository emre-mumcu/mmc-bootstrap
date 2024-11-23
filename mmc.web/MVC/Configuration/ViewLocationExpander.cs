using Microsoft.AspNetCore.Mvc.Razor;

namespace mmc.web.MVC.Configuration;

/// <summary>
/// Adds the "/Content" and "/Content/Partials" folders for view locations to the RazorViewEngine by default.
/// </summary>
/// <param name="Locations">["/Content", "/Content/Partials"]</param>
public class ViewLocationExpander(string[]? Locations = null) : IViewLocationExpander
{
	private readonly string[] ViewLocations = Locations ?? ["/Content", "/Content/Partials"];

	public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
	{
		// {2} is area, {1} is controller,{0} is the action
		// string[] locations = { "/Content/{0}" + RazorViewEngine.ViewExtension, "/Content/Layout/{0}" + RazorViewEngine.ViewExtension };		
		string[] locations = ViewLocations.Select(l => $"{l}/{{0}}{RazorViewEngine.ViewExtension}").ToArray();
		return locations.Union(viewLocations);
	}

	public void PopulateValues(ViewLocationExpanderContext context)
	{
		context.Values["customviewlocation"] = nameof(ViewLocationExpander);
	}
}