using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class ProductCategory
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public Guid? ParentId { get; set; }
    public virtual ProductCategory ParentCategory { get; set; }
}