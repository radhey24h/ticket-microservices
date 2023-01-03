using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using FMECA.Domain.Entities;
namespace FMECA.Application.Features.MetadataFMECA.Commands.Insert;

public class CreateFMECADetailsCommandHandler : IRequestHandler<CreateFMECADetailsCommand, int>
{
    private readonly IFMECADetailsRepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateFMECADetailsCommandHandler> _logger;

    public CreateFMECADetailsCommandHandler(IFMECADetailsRepository fmecaDetailsRepository, IMapper mapper, ILogger<CreateFMECADetailsCommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(CreateFMECADetailsCommand request, CancellationToken cancellationToken)
    {
        var fmecaEntity=_mapper.Map<FMECADetails>(request);
        var newfmecaEntity= await _fmecaDetailsRepository.AddAsync(fmecaEntity);
        _logger.LogInformation($" New FMECA {newfmecaEntity.FMECAId} is successfully created.");
        return newfmecaEntity.FMECAId;
    }
}
