using System.ComponentModel.DataAnnotations;
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
    public DateTime OrderTime { get; set; }

    [Required]
    public DateTime OrderUpdated { get; set; }

    public Guid? ShippingId { get; set; }
    public Shipping Shipping { get; set; }

    public Guid? ProcessByUserId { get; set; }
    public User? ProcessByUser { get; set; }

    [Required]
    public PaymentType Payment { get; set; }

    public string? pda { get; set; }
    public string? pdb { get; set; }

    [Required, MaxLength(400)]
    public string Address { get; set; }
    public double Amount { get; set; }
    public double Tax { get; set; }
    
    public List<Remarks> Remarks { get; set; }
}
