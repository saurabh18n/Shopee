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
        Where(o => o.OrderByUserId == GetUserId())
        .Include(o => o.Items).ThenInclude(oi => oi.Product)
        .Include(o => o.OrderByUser)
        .OrderByDescending(o => o.OrderTime)
        .ToListAsync());
    }

    [Authorize]
    public async Task<IActionResult> Checkout()
    {
        ViewBag.OrderUser = await _db.Users.FindAsync(Guid.Parse(User.Identity.Name));
        return View(await _db.CartItems.Where(CI => CI.UserId == GetUserId()).Include(ci => ci.Product).ToListAsync());
    }

    //Administration

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Manage()
    {
        ViewBag.Categories = await _db.Categories.Include(c => c.ParentCategory).ToListAsync();
        return View(await _db.Orders.Include(o => o.Items).Include(o => o.OrderByUser).ToListAsync());
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> o([FromRoute] Guid Id)
    {
        Order? ord = await getSingleOrder(Id);
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
    public async Task<IActionResult> Accept(Guid Id)
    {
        Order? ord = await getSingleOrder(Id);
        if (ord != null)
        {
            if (ord.Status == OrderStatus.Pending)
            {
                //checking if sufficient quantity available
                var failItems = ord.Items.Where(oi => oi.Quantity > oi.Product.StoreQty).Select(oi => new { title = oi.Product.Title, order = oi.Quantity, available = oi.Product.StoreQty }).ToList();
                if (failItems.Count > 0)
                {
                    return Json(new { success = false, message = "NO-CONTINUE", data = failItems });
                }
                else
                {
                    ord.Status = OrderStatus.Processing;
                    ord.OrderUpdated = DateTime.Now;
                    ord.ProcessByUserId = GetUserId();
                    foreach (OrderItem item in ord.Items)
                    {
                        item.Product.StoreQty = item.Product.StoreQty - item.Quantity;
                    }
                    await _db.SaveChangesAsync();
                    return Json(new { success = true, message = "Order accepted successfully" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Order can not be accepted." });
            }
        }
        else
        {
            Response.StatusCode = 404;
            return Json(new { success = false, message = "Order not found" });
        }
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Reject(Guid Id)
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
                return Json(new { success = true, message = "Order Updated successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Can not update order." });
            }
        }
        else
        {
            Response.StatusCode = 404;
            return Json(new { success = false, message = "Order Not Found" });
        }
    }


    [Authorize(Roles = Roles.Admin), ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] string remark, [FromForm] OrderStatus orderstatus, [FromForm] ShippingType shipping, [FromForm] string docket)
    {
        Order? ord = await getSingleOrder(Id);
        if (ord == null) return Ok("Order Not Found");

        if (!string.IsNullOrEmpty(remark))
        {
            _db.OrderRemarks.Add(new Remarks()
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
            Shipping ns = new Shipping()
            {
                Id = Guid.NewGuid(),
                OrderId = ord.Id,
                ShippingType = shipping,
                Carrier = "",
                Docket = docket
            };
            ord.Shipping = ns;
            _db.Shippings.Add(ns);
            ord.Shipping = ns;
        }
        if (ord.Status != OrderStatus.Completed)
        {
            ord.Status = orderstatus;
        }
        else
        {
            ViewBag.Alert = "Can not change status of completed order";
            ViewBag.AlertType = AlertType.Error;
        }

        ord.OrderUpdated = DateTime.Now;
        ord.ProcessByUserId = GetUserId();
        await _db.SaveChangesAsync();

        return View("o", await getSingleOrder(Id));

    }

    private async Task<Order?> getSingleOrder(Guid Id)
    {
        Order? Order = await _db.Orders
        .Include(o => o.OrderByUser)
        .Include(o => o.Shipping)
        .Include(o => o.Items).ThenInclude(oi => oi.Product)
        .Include(o => o.Remarks).ThenInclude(r => r.ByUser)
        .FirstOrDefaultAsync(o => o.Id == Id);
        return Order;
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