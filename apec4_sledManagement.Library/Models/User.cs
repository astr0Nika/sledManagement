using System.ComponentModel.DataAnnotations;

namespace apec4_sledManagement.Library.Models;
public class User
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }


    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(50)]
    public string UserName { get; set; }

    [Required]
    public bool IsAdmin { get; set; }

    [Required]
    [StringLength(150)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; }
}
