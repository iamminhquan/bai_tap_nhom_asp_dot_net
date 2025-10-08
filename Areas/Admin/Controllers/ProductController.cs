using BaiTapNhom02_Lan_02.Services;
using Microsoft.AspNetCore.Mvc;
namespace BaiTapNhom02_Lan_02.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices productServices) {
            _productServices = productServices;
        }

        public IActionResult CreateProduct() { 
            return View();
        }
        //[HttpPost]
        //public IActionResult CreateProduct(string productName)
        //{
        //    if (!string.IsNullOrEmpty(productName))
        //    {
        //        bool result = _productServices.AddProduct(productName);
        //        if (result) {
        //            ViewBag.Message = "Product create successfully!!!";
        //        }
        //        else{
        //            ViewBag.Message = "Faile to create product!!!";
        //        };
        //    }
        //    else
        //    {
        //        ViewBag.Message = "You need to enter some information!!!";
        //    }

        //    return View("~Views/Product/CreateProduct.cshtml");
        //}
    }
}
