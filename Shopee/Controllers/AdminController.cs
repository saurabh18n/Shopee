using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopee.Models;

namespace Shopee.Controllers;
[Authorize(Roles = Roles.Admin)]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private AppDbContext _db;

    public AdminController(ILogger<AdminController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _db = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.OrderData = await _db.Orders.GroupBy(o => o.Status).Select(o => new { status = o.Key, count = o.Count() }).ToListAsync();
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
