using Microsoft.AspNetCore.Mvc;

namespace neogym.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
