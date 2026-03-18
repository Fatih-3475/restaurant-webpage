using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
