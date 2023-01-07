using MediatR;

namespace FMECA.Application.Features.MetadataFMECAReport.Queries.GetAllMetadatFMECA;

public class GetMetadatFMECAReportQuery : IRequest<List<MetadataFMECAReportDTO>>
{
    public string UserId { get; set; }
    public GetMetadatFMECAReportQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
