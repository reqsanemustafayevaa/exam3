using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace neogym.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

      
    }
}