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
    public async Task<IActionResult> Index()
    {
        return View(await _db.Orders.
        Where(o => o.OrderByUserId == GetUserId()).Include(o => o.Items).ThenInclude(oi => oi.Product).Select(oo => new Order
        {
            Id = oo.Id,
            Status = oo.Status,
            OrderTime = oo.OrderTime,
            OrderUpdated = oo.OrderUpdated,
            Payment = oo.Payment,
            pda = oo.pda,
            pdb = oo.pdb,
            Address = oo.Address,
            Items = oo.Items
        }
        )
        .ToListAsync());
    }


    [Authorize]
    public async Task<IActionResult> Checkout()
    {
        return View(await _db.CartItems.Where(CI => CI.UserId == GetUserId()).Include(ci => ci.Product).ToListAsync());
    }

    //Administration

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Manage()
    {
        return View(await _db.Orders.Include(o => o.Items).Include(o => o.OrderByUser).ToListAsync());
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> o([FromRoute] Guid Id)
    {
        Order? ord = await _db.Orders
        .Include(O => O.OrderByUser)
        .Include(o => o.Items).ThenInclude(oi => oi.Product)
        .FirstOrDefaultAsync(o => o.Id == Id);
        if (ord != null)
        {
            return View(ord);
        }
        else
        {
            return Ok("Order Not Found");
        }
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> acc(Guid Id)
    {
        Order? ord = await getSingleOrder(Id);
        if (ord != null)
        {
            if (ord.Status == OrderStatus.Pending)
            {
                ord.Status = OrderStatus.Processing;
                ord.OrderUpdated = DateTime.Now;
                ord.ProcessByUserId = GetUserId();
                await _db.SaveChangesAsync();
                return View("o", ord);
            }
            else
            {
                Response.StatusCode = 400;
                return View("o", ord);
            }
        }
        else
        {
            Response.StatusCode = 404;
            return Json("Order Not Found");
        }
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> rej(Guid Id)
    {

        Order? ord = await getSingleOrder(Id);
        if (ord != null)
        {
            if (ord.Status == OrderStatus.Pending)
            {
                ord.Status = OrderStatus.Cancelled;
                ord.OrderUpdated = DateTime.Now;
                ord.ProcessByUserId = GetUserId();
                await _db.SaveChangesAsync();
                return View("o", ord);
            }
            else
            {
                Response.StatusCode = 400;
                return View("o", ord);
            }
        }
        else
        {
            Response.StatusCode = 404;
            return Json("Order Not Found");
        }
    }

    [HttpPost, Authorize(Roles = Roles.Admin), ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] string remark, [FromForm] OrderStatus orderstatus, [FromForm] ShippingType shipping, [FromForm] string docket)
    {

        Console.WriteLine($"Update called{remark}");

        Order? ord = await getSingleOrder(Id);
        if (ord == null) return Ok("Order Not Found");

        if (!string.IsNullOrEmpty(remark))
        {
            ord.Remarks.Add(new Remarks
            {
                Id = Guid.NewGuid(),
                Text = remark,
                ByUserId = GetUserId(),
                TimeStamp = DateTime.Now,
                OrderId = ord.Id
            });
        }

        if (!string.IsNullOrEmpty(docket))
        {
            ord.Shipping = new Shipping()
            {
                Id = Guid.NewGuid(),
                OrderId = ord.Id,
                ShippingType = shipping,
                Carrier = "",
                Docket = docket
            };

        }

        ord.OrderUpdated = DateTime.Now;
        ord.ProcessByUserId = GetUserId();
        await _db.SaveChangesAsync();
        return View("o", await getSingleOrder(Id));

    }

    private async Task<Order?> getSingleOrder(Guid Id)
    {
        return await _db.Orders
        .Include(o => o.OrderByUser)
        .Include(o => o.Shipping)
        .Include(o => o.Items).ThenInclude(oi => oi.Product)
        .Include(o => o.Remarks)
        .FirstOrDefaultAsync(o => o.Id == Id);
    }

    private Guid GetUserId()
    {
        return Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> Checkout(string address, PaymentType payment, string pda, string pdb)
    {
        Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
        Order order = new Order()
        {
            Id = Guid.NewGuid(),
            OrderByUserId = userId,
            Status = OrderStatus.Pending,
            OrderTime = DateTime.Now,
            OrderUpdated = DateTime.Now,
            Payment = payment,
            pda = pda ?? "",
            pdb = pdb ?? "",
            Address = address
        };

        List<CartItem> cil = await _db.CartItems.Where(ci => ci.UserId == userId).Include(c => c.Product).ToListAsync();
        List<OrderItem> il = cil.Select(ci =>
            new OrderItem()
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
            }
        ).ToList();

        double Amount = 0;
        double Tex = 0;
        foreach (CartItem item in cil)
        {
            double total = item.Quantity * item.Product.UnitPrice;
            Amount += total;
            double it = (total * item.Product.tax) / 100;
            Tex += it;
        }
        order.Items = il;
        order.Amount = Amount;
        order.Tax = Tex;
        _db.Orders.Add(order);
        _db.CartItems.RemoveRange(cil);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));
    }
}