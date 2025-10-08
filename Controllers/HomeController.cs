using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Models;

namespace BaiTapNhom02_Lan_02.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
        return View();
    }

    public IActionResult Parts()
    {
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult Accessories()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}