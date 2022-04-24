using Shopee.Models;
namespace Shopee;
public class CartItem
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }

}