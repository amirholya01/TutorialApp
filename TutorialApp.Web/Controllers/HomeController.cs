using Microsoft.AspNetCore.Mvc;

namespace TutorialApp.Web.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
