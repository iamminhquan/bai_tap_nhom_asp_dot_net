using BaiTapNhom02_Lan_02.Services;
using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Models;
namespace BaiTapNhom02_Lan_02.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly ProductServices _productServices;

        public ProductController(ProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            bool result = _productServices.AddProduct(product);

            if (result)
                ViewBag.Message = "Thêm sản phẩm thành công!";
            else
                ViewBag.Message = "Thêm sản phẩm thất bại!";

            return View(product);
        }

    }
}
