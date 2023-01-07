using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;

namespace FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;

public class GetMyOpenFMECAQueryHandler : IRequestHandler<GetMyOpenFMECAQuery, List<MyOpenFMECADTO>>
{
    private readonly IFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    public GetMyOpenFMECAQueryHandler(IFMECARepository fmecaDetailsRepository, IMapper mapper)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<MyOpenFMECADTO>> Handle(GetMyOpenFMECAQuery request, CancellationToken cancellationToken)
    {
        var fmecaList = await _fmecaDetailsRepository.GetAllAsync();
        return _mapper.Map<List<MyOpenFMECADTO>>(fmecaList);
    }
}
