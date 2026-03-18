using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
