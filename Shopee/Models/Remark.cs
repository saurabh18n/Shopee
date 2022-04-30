using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class Remarks
{
    public Guid Id { get; set; }

    [Required]
    public User ByUser { get; set; }

    [Required]
    public DateTime TimeStamp { get; set; }

    [Required]
    public string Text { get; set; }

}