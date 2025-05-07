using Microsoft.AspNetCore.Mvc;

namespace RealHouzing.Consume.ViewComponents.AdminLayout;

public class _AdminHeadPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
