using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class Product
{
    public Guid Id { get; set; }

    [Required, Display(Name = "Title")]
    public string Title { get; set; }

    [Required, Display(Name = "Description")]
    public string Desc { get; set; }

    [Required, Display(Name = "Quantity")]
    public int StoreQty { get; set; }

    [Required, Display(Name = "Price")]
    public double UnitPrice { get; set; }


    public List<ProductImages> Images { get; set; }

    [Required, Display(Name = "Tax rate")]
    public decimal tax { get; set; }

    [Required, DataType(DataType.MultilineText), Display(Name = "Specification")]
    public string specification { get; set; }

    [Required, Display(Name = "Category")]
    public Guid CategoryId { get; set; }
    public virtual ProductCategory Category { get; set; }

    public Guid AddedById { get; set; }
    public User AddedBy { get; set; }
}
