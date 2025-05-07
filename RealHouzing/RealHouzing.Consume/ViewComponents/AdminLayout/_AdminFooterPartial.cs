using Microsoft.AspNetCore.Mvc;

namespace RealHouzing.Consume.ViewComponents.AdminLayout;

public class _AdminFooterPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
