using Microsoft.AspNetCore.Mvc;

namespace RealHouzing.Consume.ViewComponents.AdminLayout;

public class _AdminSidebarPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
