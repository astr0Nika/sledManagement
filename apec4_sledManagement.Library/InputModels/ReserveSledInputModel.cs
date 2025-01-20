using apec4_sledManagement.Library.Models;

namespace apec4_sledManagement.Library.InputModels;
public class ReserveSledInputModel
{
    public SledType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
