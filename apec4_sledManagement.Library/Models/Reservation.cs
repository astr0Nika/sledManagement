using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apec4_sledManagement.Library.Models;

[PrimaryKey(nameof(UserId), nameof(SledNumber))]
public class Reservation 
{
    public Guid UserId { get; set; }

    public int SledNumber { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public DateTime BeginDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("SledNumber")]
    public virtual Sled Sled { get; set; }
}
