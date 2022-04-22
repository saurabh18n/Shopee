using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    public string Username { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Required]
    public string Location { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string ContactNumber { get; set; }

    [Required]
    public bool IsAdmin { get; set; }

}
