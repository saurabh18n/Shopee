using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class Order
{
    [Required, Key]
    public Guid Id { get; set; }

    [Required]
    public Guid OrderByUserId { get; set; }
    public User OrderByUser { get; set; }

    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    public List<OrderItem> Items { get; set; }

    [Required]
    public Guid ProcessByUserId { get; set; }
    public User ProcessByUser { get; set; }
}
