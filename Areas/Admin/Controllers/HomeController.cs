using BaiTapNhom02_Lan_02.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom02_Lan_02.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController(ProductServices productServices) : Controller
    {
        private readonly ProductServices _productServices = productServices;

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
            var products = _productServices.GetAllProducts();
            return View(products);
        }
    }
}