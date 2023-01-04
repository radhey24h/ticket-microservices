using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Application.Contracts.Persistence;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;

public class GetAllMetadatFMECAQueryHandler : IRequestHandler<GetAllMetadatFMECAQuery, List<MetadatFMECADTO>>
{
    private readonly IFMECADetailsRepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    public GetAllMetadatFMECAQueryHandler(IFMECADetailsRepository fmecaDetailsRepository, IMapper mapper)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<MetadatFMECADTO>> Handle(GetAllMetadatFMECAQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecaDetailsRepository.GetFMECAByUserIdAsync(request.UserId);
        return _mapper.Map<List<MetadatFMECADTO>>(fmecaList);
    }
}
