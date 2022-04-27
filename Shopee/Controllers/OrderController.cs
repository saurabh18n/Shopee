using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Shopee.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly AppDbContext _db;

    public OrderController(ILogger<OrderController> logger, AppDbContext ctx)
    {
        _db = ctx;
        _logger = logger;
    }

    [Authorize]
    public async Task<IActionResult> checkout()
    {
        Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
        return View(await _db.CartItems.Where(CI => CI.UserId == userId).Include(ci => ci.Product).ToListAsync());
    }
}