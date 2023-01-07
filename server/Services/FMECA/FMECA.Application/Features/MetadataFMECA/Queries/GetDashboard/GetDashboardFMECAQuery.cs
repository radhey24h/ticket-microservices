using FMECA.Application.Features.MetadataFMECA.Queries.GetDashboard;
using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;

public class GetDashboardFMECAQuery : IRequest<List<DashboardFMECADTO>>
{
    public string UserId { get; set; }
    public GetDashboardFMECAQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
