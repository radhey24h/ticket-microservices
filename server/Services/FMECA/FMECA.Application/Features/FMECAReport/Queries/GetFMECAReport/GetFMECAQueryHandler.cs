using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Application.Contracts.Persistence;

namespace FMECA.Application.Features.FMECAReport.Queries.GetAllMetadatFMECA;

public class GetFMECAQueryHandler : IRequestHandler<GetFMECAReportQuery, List<FMECAReportDTO>>
{
    private readonly IFMECAReportRepository _fmecaReportRepository;
    private readonly IMapper _mapper;
    public GetFMECAQueryHandler(IFMECAReportRepository fmecaReportRepository, IMapper mapper)
    {
        _fmecaReportRepository = fmecaReportRepository ?? throw new ArgumentNullException(nameof(fmecaReportRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<FMECAReportDTO>> Handle(GetFMECAReportQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecaReportRepository.GetAllAsync();
        return _mapper.Map<List<FMECAReportDTO>>(fmecaList);
    }
}
