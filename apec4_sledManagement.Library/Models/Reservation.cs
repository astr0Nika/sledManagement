using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apec4_sledManagement.Library.Models;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public int SledNumber { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("SledNumber")]
    public virtual Sled Sled { get; set; }
}
