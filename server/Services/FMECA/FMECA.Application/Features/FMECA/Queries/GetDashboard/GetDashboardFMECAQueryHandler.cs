using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;
using FMECA.Domain.Common.Enum;
using MediatR;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace FMECA.Application.Features.FMECA.Queries.GetDashboard;

public class GetDashboardFMECAQueryHandler : IRequestHandler<GetDashboardFMECAQuery, DashboardFMECADTO>
{
    private readonly IFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    public GetDashboardFMECAQueryHandler(IFMECARepository fmecaDetailsRepository, IMapper mapper)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DashboardFMECADTO> Handle(GetDashboardFMECAQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecaDetailsRepository.GetAllAsync();

        return new DashboardFMECADTO()
        {
            TotalFMECATypeCount = GetTotalFMECATypeCount(fmecaList),
            TotalFMECATypeCountOne = GetTotalFMECATypeCountOne(fmecaList),
            TotalFMECAStatus = GetTotalFMECAStatus(fmecaList),
            MyOpenFMECA = _mapper.Map<IEnumerable<MyOpenFMECADTO>>(fmecaList)
        };
    }

    private dynamic GetTotalFMECATypeCount(IReadOnlyList<Domain.Entities.FMECA> fmecaList)
    {
        return fmecaList.GroupBy(x => new { x.FMECAType, x.ProcessFMECAType })
                   .Select(g =>
                   new
                   {
                       g.Key.FMECAType,
                       g.Key.ProcessFMECAType,
                       count = g.Count()
                   });
    }
    private Dictionary<Tuple<string, string>, int> GetTotalFMECATypeCountOne(IReadOnlyList<Domain.Entities.FMECA> fmecaList)
    {
        return fmecaList.GroupBy(x => Tuple.Create(x.FMECAType, x.ProcessFMECAType))
               .ToDictionary(g => g.Key, g => g.Count());

    }
    private dynamic GetTotalFMECAStatus(IReadOnlyList<Domain.Entities.FMECA> fmecaList)
    {
        return fmecaList.GroupBy(x => new { x.FMECAStatus })
                  .Select(g =>
                  new
                  {
                      g.Key.FMECAStatus,
                      count = g.Count()
                  });
    }
}
