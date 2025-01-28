using Microsoft.AspNetCore.Mvc;

namespace MouseTracker.Web.Controllers;

public sealed class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}