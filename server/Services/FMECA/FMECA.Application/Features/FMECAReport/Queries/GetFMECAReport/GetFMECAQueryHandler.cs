using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;

namespace FMECA.Application.Features.FMECAReport.Queries.GetFMECAReport;

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
