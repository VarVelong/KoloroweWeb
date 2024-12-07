using Microsoft.AspNetCore.Mvc;

namespace KoloroweWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
