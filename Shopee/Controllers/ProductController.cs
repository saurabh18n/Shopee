using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shopee.Controllers;
public class ProductController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private AppDbContext _db;

    public ProductController(ILogger<HomeController> logger, AppDbContext appDbContext)
    {
        _db = appDbContext;
        _logger = logger;
    }

    public async Task<IActionResult> Index([FromQuery] string? Search, [FromQuery] float Max, [FromQuery] float Min, [FromQuery] string cat)
    {
        List<Product> Products = await _db.Products.Where(prod =>
        (string.IsNullOrEmpty(Search) || (prod.Title.Contains(Search) && prod.Desc.Contains(Search))) &&
        ((cat == "All" || string.IsNullOrEmpty(cat)) || (prod.Category.Category.Contains(Search))) &&
        (Max == 0 || prod.UnitPrice <= Max) &&
        (Min == 0 || prod.UnitPrice >= Min)
       )
       .Include(p => p.Images).Take(10)
        .ToListAsync();
        ViewBag.Categories = await _db.Categories.ToListAsync();
        return View(Products);
    }

    public async Task<IActionResult> p(Guid Id)
    {
        Product? prod = await _db.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == Id);
        if (prod != null)
        {
            return View(prod);
        }
        else
        {
            ViewBag.Alert = "Invalid Product";
            return View();

        }
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create()
    {
        var categories = await _db.Categories.ToListAsync();
        ViewBag.Categories = categories;
        return View();
    }

    [Authorize(Roles = Roles.Admin), HttpPost]
    public async Task<IActionResult> Create(Product prod, IFormFile mainimage, List<IFormFile> ImageFiles)
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            prod.AddedById = Guid.Parse(User?.Identity?.Name ?? (new Guid()).ToString());
            _db.Products.Add(prod);
            foreach (var imageFile in ImageFiles)
            {
                ProductImages pd = new ProductImages()
                {
                    Id = Guid.NewGuid(),
                    ProductId = prod.Id
                };
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length < 2097152)
                    {
                        pd.Image = memoryStream.ToArray();
                    }
                }
                _db.ProductImages.Add(pd);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("ManageProducts");

        }
        else
        {
            return RedirectToAction(controllerName: "Account", actionName: "Login");
        }

    }


    public async Task<IActionResult> Manage()
    {
        ViewBag.Categories = await _db.Categories.ToListAsync();
        List<Product> prod = await _db.Products
        .Include(p => p.Category).ThenInclude(p => p.ParentCategory).ToListAsync();
        return View(prod);
    }


    public async Task<IActionResult> Edit(Guid Id)
    {
        Product? prod = await _db.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == Id);
        List<ProductCategory> catlist = await _db.Categories.Include(c => c.ParentCategory).ToListAsync();
        if (prod != null)
        {
            ViewBag.Categories = catlist;
            return View(prod);
        }
        else
        {
            return Ok("Product Not Found");
        }
    }

    public async Task<IActionResult> DeleteImage(Guid Id)
    {
        var pi = _db.ProductImages.FirstOrDefault(p => p.Id == Id);
        _db.ProductImages.Remove(pi);
        await _db.SaveChangesAsync();
        return Ok(new { success = true, message = "delete successfully" });
    }

    [HttpPost, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> AddQuantity(Guid Id, int quantity)
    {
        Product? prod = _db.Products.Find(Id);
        if (prod == null)
        {
            return Json(new { success = false, message = "Not Found" });
        }
        else
        {
            prod.StoreQty += quantity;
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Quantity Updated Successfully" });
        }
    }


    [Authorize(Roles = Roles.Admin), HttpPost]
    public async Task<IActionResult> Update(Guid Id, Product prod, IFormFile mainimage, List<IFormFile> ImageFiles)
    {

        prod.AddedById = Guid.Parse(User?.Identity?.Name ?? (new Guid()).ToString());
        foreach (var imageFile in ImageFiles)
        {
            ProductImages pd = new ProductImages()
            {
                Id = Guid.NewGuid(),
                ProductId = prod.Id
            };
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                if (memoryStream.Length < 2097152)
                {
                    pd.Image = memoryStream.ToArray();
                }
            }
            _db.ProductImages.Add(pd);
        }
        _db.Products.Update(prod);
        await _db.SaveChangesAsync();
        return RedirectToAction("ManageProducts");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
