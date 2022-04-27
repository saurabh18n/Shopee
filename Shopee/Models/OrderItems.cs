using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class OrderItem
{
    [Required, Key]
    public Guid Id { get; set; }

    [Required]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    [Required]
    public int Quantity { get; set; }
}
