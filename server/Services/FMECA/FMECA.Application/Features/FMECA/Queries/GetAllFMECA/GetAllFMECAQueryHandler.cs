using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Application.Contracts.Persistence;

namespace FMECA.Application.Features.FMECA.Queries.GetAllFMECA;

public class GetAllFMECAQueryHandler : IRequestHandler<GetAllFMECAQuery, List<FMECADTO>>
{
    private readonly IFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    public GetAllFMECAQueryHandler(IFMECARepository fmecaDetailsRepository, IMapper mapper)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<FMECADTO>> Handle(GetAllFMECAQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecaDetailsRepository.GetAllAsync();
        return _mapper.Map<List<FMECADTO>>(fmecaList);
    }
}
