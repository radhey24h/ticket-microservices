using FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;
using FMECA.Domain.Common.Enum;

namespace FMECA.Application.Features.FMECA.Queries.GetDashboard;

public class DashboardFMECADTO
{
    public dynamic TotalFMECATypeCount { get; set; }
    public dynamic TotalFMECAStatus { get; set; }
    public IEnumerable<MyOpenFMECADTO> MyOpenFMECA { get; set; }
}
