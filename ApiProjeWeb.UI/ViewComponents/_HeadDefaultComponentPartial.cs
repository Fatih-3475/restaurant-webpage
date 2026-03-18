using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.ViewComponents
{
    public class _HeadDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
