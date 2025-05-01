using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FrontEndOfCode.Models;
using TestingForAssignment;

namespace FrontEndOfCode.Controllers;

public class HomeController : Controller
{
    private readonly DefaultDiscountService _discountService = new DefaultDiscountService();

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Index(int age, string gameMode)
    {
        var service = new GameService(_discountService);
        var premium = service.CalcPremium(age, gameMode);
        ViewBag.Premium = premium;
        return View();
    }
}
