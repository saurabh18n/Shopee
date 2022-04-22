using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWebApp.Models;

namespace OnlineShoppingWebApp.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost, ActionName("Login")]
    public IActionResult LoginPost()
    {
        return View();
    }

    public IActionResult Register([FromForm] string username, [FromForm] string passsword, [FromForm] string something)
    {
        return View();
    }
    [HttpPost, ActionName("Register")]
    public IActionResult RegisterPost()
    {
        return View();
    }







    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
