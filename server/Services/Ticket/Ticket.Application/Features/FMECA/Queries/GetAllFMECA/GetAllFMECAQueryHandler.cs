using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Contracts.Persistence;

namespace Ticket.Application.Features.FMECA.Queries.GetAllFMECA;

public class GetAllFMECAQueryHandler : IRequestHandler<GetAllFMECAQuery, List<FMECADTO>>
{
    private readonly IFMECARepository _fmecarepository;
    private readonly IMapper _mapper;
    public GetAllFMECAQueryHandler(IFMECARepository fmecarepository, IMapper mapper)
    {
        _fmecarepository = fmecarepository ?? throw new ArgumentNullException(nameof(fmecarepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<FMECADTO>> Handle(GetAllFMECAQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecarepository.GetFMECAByUserIdAsync(request.UserId);
        return _mapper.Map<List<FMECADTO>>(fmecaList);
    }
}
