using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
