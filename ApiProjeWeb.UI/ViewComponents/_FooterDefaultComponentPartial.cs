using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.ViewComponents
{
    public class _FooterDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
