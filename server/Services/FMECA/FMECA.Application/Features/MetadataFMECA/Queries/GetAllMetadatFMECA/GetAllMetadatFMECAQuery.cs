using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;

public class GetAllMetadatFMECAQuery : IRequest<List<MetadatFMECADTO>>
{
    public string UserId { get; set; }
    public GetAllMetadatFMECAQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
