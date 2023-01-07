using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Features.MetadataFMECA.Queries.GetDashboard;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;

public class GetDashboardFMECAQueryHandler : IRequestHandler<GetDashboardFMECAQuery, List<DashboardFMECADTO>>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    public GetDashboardFMECAQueryHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<DashboardFMECADTO>> Handle(GetDashboardFMECAQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecaDetailsRepository.GetAllAsync();
        return _mapper.Map<List<DashboardFMECADTO>>(fmecaList);
    }
}
