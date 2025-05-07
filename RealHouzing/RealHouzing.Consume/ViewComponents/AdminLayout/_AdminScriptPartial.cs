using Microsoft.AspNetCore.Mvc;

namespace RealHouzing.Consume.ViewComponents.AdminLayout;

public class _AdminScriptPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
