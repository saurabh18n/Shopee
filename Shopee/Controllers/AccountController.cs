using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWebApp.Models;

namespace OnlineShoppingWebApp.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private AppDbContext _DB;

    public AccountController(ILogger<AccountController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _DB = dbContext;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost, AllowAnonymous, ActionName("login"), ValidateAntiForgeryToken]
    async public Task<IActionResult> LoginPost([FromForm] string username, [FromForm] string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Username or password was empty";
            return View();
        }
        var loginUser = _DB.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (loginUser == null)
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginUser.Username),
            new Claim("FullName", loginUser.FirstName + " " + loginUser.LastName)
        };
        if (loginUser.IsAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            claims.Add(new Claim(ClaimTypes.Role, "User"));
        }
        else
        {
            claims.Add(new Claim(ClaimTypes.Role, "User"));
        }
        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        if (loginUser.IsAdmin)
        {
            return Redirect(Url.Action("index", "admin"));

        }
        else
        {
            return Redirect(Url.Action("index", "home"));

        }
    }
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect(Url.Action("index", "home"));
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost, ActionName("Register"), ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterPost(User user)
    {
        if (ModelState.IsValid)
        {
            user.Id = Guid.NewGuid();
            user.IsAdmin = false;
            _DB.Users.Add(user);
            await _DB.SaveChangesAsync();
            ViewBag.Alert = "Registered Successfully";
            return View("~/Views/Home/Index.cshtml");
        }
        else
        {
            ViewBag.ErrorMessage = "invalid Model";
        }
        return View();
    }

    public IActionResult Noaccess()
    {
        return View();
    }






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
