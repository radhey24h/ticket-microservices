using FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;

namespace FMECA.Application.Features.FMECA.Queries.GetDashboard;

public class DashboardFMECADTO
{
    public UserDTO User { get; set; }
    public TotalFMECACountDTO TotalFMECACountDTO { get; set; }
    public TotalFMECAStatusDTO TotalFMECAByStatusDTO { get; set; }
    public IEnumerable<MyOpenFMECADTO> MyOpenFMECADTO { get; set; }
}
public class UserDTO
{
    public string userName { get; set; }
}
public class TotalFMECACountDTO
{
    public int SystemFMECA { get; set; }
    public int SesignFMECA { get; set; }
    public int SafteyFMECA { get; set; }
    public int ProcessFMECA { get; set; }
    public int ElectricProcessFmeca { get; set; }
    public int ManufacturingProcessFMECA { get; set; }
    public int MechanicalProcessFMECA { get; set; }
}
public class TotalFMECAStatusDTO
{
    public int Draft { get; set; }
    public int AssessmentUnderprocess { get; set; }
}