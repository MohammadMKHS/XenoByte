using Microsoft.AspNetCore.Mvc;

namespace XenoByte.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

