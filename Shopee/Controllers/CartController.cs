//#nullable disable
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Shopee.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet, Authorize]
        public async Task<IActionResult> Index()
        {
            Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
            return View(await _context.CartItems.Where(CI => CI.UserId == userId).Include(ci => ci.Product).ToListAsync());
        }

        [Authorize]
        public async Task<ActionResult<CartItem>> add(Guid ProdId, int quantity)
        {
            if (ProdId != Guid.Empty && quantity > 0)
            {
                Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
                CartItem? exci = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == ProdId && c.UserId == userId);
                if (exci == null)
                {
                    _context.CartItems.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        ProductId = ProdId,
                        Quantity = quantity
                    });
                }
                else
                {
                    exci.Quantity += quantity;
                }
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "SNo" });
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        public async Task<IActionResult> Remove(Guid id)
        {
            Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => (c.Id == id) && (c.UserId == userId));
            if (cartItem == null)
            {
                return Ok(new { success = false, message = "Item not found" });
            }
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Reset()
        {
            Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
            List<CartItem> Itmes = await _context.CartItems.Where(c => c.UserId == userId).ToListAsync();
            _context.CartItems.RemoveRange(Itmes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(Guid id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
