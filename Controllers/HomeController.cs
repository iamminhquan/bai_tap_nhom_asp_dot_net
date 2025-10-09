using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Models;
using BaiTapNhom02_Lan_02.Services;

namespace BaiTapNhom02_Lan_02.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductServices _productServices;

    public HomeController(ILogger<HomeController> logger, ProductServices productServices)
    {
        _logger = logger;
        _productServices = productServices;
    }

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
        //ViewBag.pageName = "Bicycles";
        var products = _productServices.GetAllProducts();
        return View(products);
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        ViewBag.pageName = "Extras";
        return View();
    }
}
//new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }