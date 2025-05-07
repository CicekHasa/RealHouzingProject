using Microsoft.AspNetCore.Mvc;

namespace RealHouzing.Consume.ViewComponents.AdminLayout;

public class _AdminNavbarPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
