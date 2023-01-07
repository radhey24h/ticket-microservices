using MediatR;

namespace FMECA.Application.Features.FMECAReport.Queries.GetFMECAReport;

public class GetFMECAReportQuery : IRequest<List<FMECAReportDTO>>
{
    public string UserId { get; set; }
    public GetFMECAReportQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
