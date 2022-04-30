using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

[Table("order_remarks")]
public class Remarks
{
    public Guid Id { get; set; }

    [Required]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    public Guid ByUserId { get; set; }
    public User ByUser { get; set; }

    [Required]
    public DateTime TimeStamp { get; set; }

    [Required]
    public string Text { get; set; }

}