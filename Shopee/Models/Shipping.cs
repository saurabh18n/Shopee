using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shopee.Models;

public class Shipping
{
    [Required, Key]
    public Guid Id { get; set; }

    [Required]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    public String Carrier { get; set; }

    [Required]
    public String Docket { get; set; }

}