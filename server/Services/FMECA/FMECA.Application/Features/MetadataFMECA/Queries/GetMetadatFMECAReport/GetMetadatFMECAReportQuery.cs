using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;

public class GetMetadatFMECAReportQuery : IRequest<List<MetadatFMECAReportDTO>>
{
    public string UserId { get; set; }
    public GetMetadatFMECAReportQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
