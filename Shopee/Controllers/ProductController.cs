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
public class ProductController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private AppDbContext _db;

    public ProductController(ILogger<HomeController> logger, AppDbContext appDbContext)
    {
        _db = appDbContext;
        _logger = logger;
    }



    public async Task<IActionResult> Index()
    {
        ViewBag.Products = await _db.Products.Include(p => p.Images).Take(10).ToListAsync();
        return View();
    }

    public async Task<IActionResult> Product(Guid Id)
    {
        Product? prod = await _db.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == Id);
        if (prod != null)
        {
            ViewBag.Product = prod;
            return View();
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


    public async Task<IActionResult> ManageProducts()
    {
        ViewBag.Products = await _db.Products.Take(10).ToListAsync();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {


        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
