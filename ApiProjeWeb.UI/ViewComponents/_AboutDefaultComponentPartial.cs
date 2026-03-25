using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.ViewComponents
{
    public class _AboutDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
