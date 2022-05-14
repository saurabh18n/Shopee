using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;

namespace Shopee.Controllers;

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
    async public Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
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
            new Claim(ClaimTypes.Name, loginUser.Id.ToString()),
            new Claim("FName", loginUser.FirstName),
            new Claim("LName", loginUser.LastName),
        };
        if (loginUser.IsAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, Roles.Admin));
            claims.Add(new Claim(ClaimTypes.Role, Roles.User));
        }
        else
        {
            claims.Add(new Claim(ClaimTypes.Role, Roles.User));
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
            return Redirect(Url.Action("index", "admin") ?? "/");

        }
        else
        {
            return Redirect(Url.Action("index", "home") ?? "/");

        }
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect(Url.Action("index", "home") ?? "/");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, ActionName("Register"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            user.Id = Guid.NewGuid();
            user.IsAdmin = false;
            _DB.Users.Add(user);
            await _DB.SaveChangesAsync();
            return View("success", user);
        }
        else
        {
            ViewBag.ErrorMessage = "Please Fill all details";
        }
        return View();
    }

    [HttpGet, Authorize]
    public IActionResult Profile()
    {
        User usr = _DB.Users.First(u => u.Id == Guid.Parse(User.Identity.Name));
        return View(usr);
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> Update(string address, string password, string newpass, string email, string phone, string fname, string lname)
    {
        string message = "";
        User usr = _DB.Users.First(u => u.Id == Guid.Parse(User.Identity.Name));
        if (usr == null)
        {
            return Ok(new { success = true, message = "User not found" });
        }
        else
        {
            if (!string.IsNullOrEmpty(address))
            {
                usr.Address = address;

            }
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(newpass))
            {
                if (password == usr.Password)
                {
                    usr.Password = newpass;
                }
                else
                {
                    message = "Old Password do not match ";
                }
            }

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone))
            {
                usr.ContactNumber = phone;
                usr.Email = email;
            }


            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname))
            {
                usr.FirstName = fname;
                usr.LastName = lname;
            }


            await _DB.SaveChangesAsync();
            return Ok(new { success = message == "" ? true : false, message = message == "" ? "Updated Successfully" : message });
        }
    }


    public IActionResult Noaccess()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true),]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
