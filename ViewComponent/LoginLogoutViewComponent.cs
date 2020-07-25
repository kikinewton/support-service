using Microsoft.AspNetCore.Mvc;

namespace SupportService.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
        
    }
}
