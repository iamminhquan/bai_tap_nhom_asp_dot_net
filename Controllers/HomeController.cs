using Microsoft.AspNetCore.Mvc;

// Minh Quân.
// Đưa class HomeController vào namespace BaiTapNhom02_Lan_02.Controllers.
// Ngày chỉnh sửa: 08/10/2025 - 11:25 PM.
namespace BaiTapNhom02_Lan_02.Controllers
{
    // Minh Quân.
    // Thay default contructor bằng primary contructor.
    // Ngày chỉnh sửa: 08/10/2025 - 11:27 PM.
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
        {
            ViewBag.isIndex = true;
            return View();
        }

        public IActionResult Single()
        {
            return View();
        }

        public IActionResult Bicycles()
        {
            ViewBag.pageName = "Bicycles";
            return View();
        }

        public IActionResult Parts()
        {
            ViewBag.pageName = "Parts";
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Accessories()
        {
            ViewBag.pageName = "Accessories";
            return View();
        }

        // Minh Quân
        // Thêm chức năng đăng ký.
        // Ngày chỉnh sửa: 08/10/2025 - 11:30 PM.
        public IActionResult SignUp()
        {
            ViewBag.pageName = "SignUp";
            return View();
        }

        // Minh Quân
        // Thêm chức năng đăng nhập.
        // Ngày chỉnh sửa: 08/10/2025 - 11:22 PM.
        public IActionResult SignIn()
        {
            ViewBag.pageName = "SignIn";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.pageName = "Extras";
            return View();
        }
    }
}
