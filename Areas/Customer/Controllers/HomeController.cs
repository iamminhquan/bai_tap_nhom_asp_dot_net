using BaiTapNhom02_Lan_02.Models;
using BaiTapNhom02_Lan_02.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom02_Lan_02.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController(ProductServices productServices) : Controller
    {
        private readonly ProductServices _productServices = productServices;

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Auth");

            ViewBag.isIndex = true;
            var products = _productServices.GetAllProducts().Take(3);
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View(products);
        }

        public IActionResult Accessories()
        {
            return View();
        }

        public IActionResult Parts()
        {
            return View();
        }

        public IActionResult Bicycles()
        {
            var products = _productServices.GetAllProducts();
            //ViewBag.Username = HttpContext.Session.GetString("Username");
            return View(products);
        }

        public IActionResult Carts()
        {
            return View();
        }

        public IActionResult Single()
        {
            return View();
        }
    }
}