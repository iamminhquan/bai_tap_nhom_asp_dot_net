using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom02_Lan_02.Controllers
{
    public class LoginController(ILogger<LoginController> logger) : Controller
    {
        private readonly ILogger<LoginController> _logger = logger;

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
