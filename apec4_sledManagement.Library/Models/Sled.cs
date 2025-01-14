using System.ComponentModel.DataAnnotations;

namespace apec4_sledManagement.Library.Models;
public class Sled
{
    [Key]
    public int SledNumber { get; set; }

    [Required]
    [Range(0, 3)]
    public SledType Type { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }
}
