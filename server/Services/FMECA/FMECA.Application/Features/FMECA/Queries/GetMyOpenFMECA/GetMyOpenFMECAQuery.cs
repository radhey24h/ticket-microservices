using MediatR;

namespace FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;

public class GetMyOpenFMECAQuery : IRequest<List<MyOpenFMECADTO>>
{
    public string UserId { get; set; }
    public GetMyOpenFMECAQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
