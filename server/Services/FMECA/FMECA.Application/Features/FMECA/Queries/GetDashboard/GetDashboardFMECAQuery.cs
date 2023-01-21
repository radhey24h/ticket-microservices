using FMECA.Application.Features.FMECA.Queries.GetDashboard;
using MediatR;

namespace FMECA.Application.Features.FMECA.Queries.GetDashboard;

public class GetDashboardFMECAQuery : IRequest<DashboardFMECADTO>
{
    public string UserId { get; set; }
    public GetDashboardFMECAQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
