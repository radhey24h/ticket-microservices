using FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.MetadataFMECA.Queries.GetMyOpenFMECA;
using FMECA.Domain.Common.Enum;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetDashboard;

public class DashboardFMECADTO
{
    public UserDTO User { get; set; }
    public TotalFMECACountDTO TotalFMECACountDTO { get; set; }
    public TotalFMECAByStatusDTO TotalFMECAByStatusDTO { get; set; }
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
public class TotalFMECAByStatusDTO
{
    public int Draft { get; set; }
    public int AssessmentUnderprocess { get; set; }
}