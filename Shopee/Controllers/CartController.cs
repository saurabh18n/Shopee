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

namespace Shopee
{
    [ApiController]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet, Authorize, Route("/Cart")]
        public async Task<IActionResult> Index()
        {
            Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
            ViewBag.CartItems = await _context.CartItems.Where(CI => CI.UserId == userId).ToListAsync();
            return View();
        }



        [Authorize, Route("/cart/add")]
        public async Task<ActionResult<CartItem>> add(Guid ProdId, int quantity)
        {
            if (ProdId != Guid.Empty && quantity > 0)
            {
                Guid userId = Guid.Parse(User?.Identity?.Name ?? new Guid().ToString());
                _context.CartItems.Add(new CartItem
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    ProductId = ProdId,
                    Quantity = quantity
                });
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "Successfully Added Item To Cart" });
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return Ok(new { success = false, message = "Item not found" });
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartItemExists(Guid id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
