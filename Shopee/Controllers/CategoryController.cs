using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await _dbContext.Categories.Include(c => c.ParentCategory).OrderBy(c => c.ParentId.HasValue).ToListAsync();
        return View();
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Add()
    {
        ViewBag.ParentCategories = new SelectList(await _dbContext.Categories.Where(c => c.ParentId == null)
           .ToDictionaryAsync(c => c.Id, c => c.Category), "Key", "Value");
        return View();
    }

    [HttpPost, Authorize(Roles = Roles.Admin), ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(ProductCategory cat)
    {

        try
        {
            cat.Id = Guid.NewGuid();
            _dbContext.Categories.Add(new ProductCategory()
            {
                Category = cat.Category,
                ParentId = cat.ParentId
            });
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Ok("Something Went Wrong");
        }
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Edit(Guid Id)
    {
        List<ProductCategory> categoryList = new List<ProductCategory>();
        categoryList.Add(new ProductCategory() { Id = Guid.Empty, Category = "Root", ParentId = null });
        categoryList.AddRange(await _dbContext.Categories.Where(c => c.ParentId == null).ToListAsync());
        ViewBag.ParentCategories = new SelectList(categoryList, "Id", "Category");

        ProductCategory? category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);
        if (category != null)
        {
            return View(category);
        }
        else
        {
            return Ok("Product Not Found");
        }
    }

    [HttpPost, Authorize(Roles = Roles.Admin), ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductCategory cat)
    {
        ProductCategory? categoryDB = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == cat.Id);

        if (categoryDB != null)
        {
            categoryDB.Category = cat.Category;
            if (cat.ParentId == Guid.Empty)
            {
                categoryDB.ParentId = null;
            }
            else
            {
                categoryDB.ParentId = cat.ParentId;
            }
            await _dbContext.SaveChangesAsync();
            ViewBag.Alert = "Category Updated Successfully";
            return RedirectToAction("Index");
        }
        else
        {
            return Ok("Product Not Found");
        }
    }








    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}