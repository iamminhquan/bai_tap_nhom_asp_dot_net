using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Models;
using BaiTapNhom02_Lan_02.Services;

// Minh Quân.
// Thay default contructor bằng primary contructor.
// Ngày chỉnh sửa: 08/10/2025 - 11:27 PM.
public class HomeController(ILogger<HomeController> logger, ProductServices productServices) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly ProductServices _productServices = productServices;

    public IActionResult Index()
    {
        ViewBag.isIndex = true;
        var products = _productServices.GetAllProducts().Take(3);
        return View(products);
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
    // Chỉnh sửa chức năng đăng nhập.
    // Ngày chỉnh sửa: 11/10/2025 - 5:08 PM.
    public IActionResult Login()
    {
        ViewBag.pageName = "Login";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        ViewBag.pageName = "Extras";
        return View();
    }
}

