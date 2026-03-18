using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.UI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarFormInlineAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
