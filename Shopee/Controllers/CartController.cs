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



        [HttpPost, Authorize, Route("/Cart")]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartItem", new { id = cartItem.Id }, cartItem);
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
