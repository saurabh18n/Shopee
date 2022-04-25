using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopee.Models;

namespace Shopee.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private AppDbContext _dbContext;

    public CategoryController(ILogger<CategoryController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    [Authorize(Roles = Roles.Admin)]
    public IActionResult Index()
    {
        ViewBag.Categories = _dbContext.Categories.Include(c => c.ParentCat).ToList();
        return View();
    }

    [Authorize(Roles = Roles.Admin)]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost, Authorize(Roles = Roles.Admin), ValidateAntiForgeryToken]
    public IActionResult Add(ProductCategory category)
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
