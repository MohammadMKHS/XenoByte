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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            /*
            1- get the user from the applicationContext by email
            2- check if the user exist in the DB
            3- use PasswordHelper.VerifyPassword(password,storedHash,storedSalt) to verify if the passowrd is correct
            4- retunrn validation errors
            5- go to home index if there is no errors
             
             */

            return View();
        }


    }







}

