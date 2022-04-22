using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

[Table("product_images")]
public class ProductImages
{
    public Guid Id { get; set; }

    [Required]
    public Product Product { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public byte[] Image { get; set; }
}