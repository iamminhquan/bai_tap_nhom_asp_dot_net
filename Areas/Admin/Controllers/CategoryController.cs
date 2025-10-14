using BaiTapNhom02_Lan_02.Services;
using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Models;

//thai nguyen
//viet controller
// 13/10/25  9h40p
namespace BaiTapNhom02_Lan_02.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryServices _categoryServices;

        public CategoryController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Categories category)
        {
            bool result = _categoryServices.AddCategory(category);

            if (result)
                ViewBag.Message = "Thêm danh mục thành công!";
            else
                ViewBag.Message = "Thêm danh mục thất bại!";

            return View(category);
        }
    }
}
