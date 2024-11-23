using Microsoft.AspNetCore.Mvc;

namespace mmc.bootstrap.demo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index([Bind(Prefix = "id")] string? ComponentName) => View(model: ComponentName);
}