using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom02_Lan_02.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Management()
        {
            ViewData["Title"] = "Management";
            ViewBag.Message = "Page Management";
            return View();
        }

        public IActionResult ProductManagement()
        {
            ViewData["Title"] = "ProductManagement";
            ViewBag.Message = "Page ProductManagement";
            return View();
        }
    }
}