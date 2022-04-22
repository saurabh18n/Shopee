using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string Desc { get; set; }
    public int Quantity { get; set; }

    public double UnitPrice { get; set; }
    public string ImageUrl { get; set; }
}
