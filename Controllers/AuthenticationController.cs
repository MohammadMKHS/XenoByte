using Microsoft.AspNetCore.Mvc;
using XenoByte.AppManager;

namespace XenoByte.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationContext applicationContext;
        public AuthenticationController(ApplicationContext ApplicationContext)
        {
            applicationContext = ApplicationContext;
        }
        public IActionResult Index()
        {
            var sss = applicationContext.User.FirstOrDefault(x => x.Email == "admin@example.com");
            return View();
        }
    }
}

