﻿using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllFMECA;

public class GetAllFMECAQuery : IRequest<List<FMECADTO>>
{
    public string UserId { get; set; }
    public GetAllFMECAQuery(string userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}
