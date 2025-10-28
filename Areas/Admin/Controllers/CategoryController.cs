using BaiTapNhom02_Lan_02.Services;
using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Models;

//thai nguyen
//viet controller
// 13/10/25  9h40p
namespace BaiTapNhom02_Lan_02.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(CategoryServices categoryServices) : Controller
    {
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            bool result = await categoryServices.AddCategoryAsync(category);

            ViewBag.Message = result
                ? "Thêm danh mục thành công!"
                : "Thêm danh mục thất bại!";

            return View(category);
        }
    }
}
