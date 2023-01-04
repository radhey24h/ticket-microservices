using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using FMECA.Domain.Entities;
namespace FMECA.Application.Features.MetadataFMECA.Commands.Insert;

public class CreateMetadatFMECACommandHandler : IRequestHandler<CreateMetadatFMECACommand, int>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateMetadatFMECACommandHandler> _logger;

    public CreateMetadatFMECACommandHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<CreateMetadatFMECACommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(CreateMetadatFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaEntity= _mapper.Map<Domain.Entities.MetadataFMECA>(request);
        var newfmecaEntity= await _fmecaDetailsRepository.AddAsync(fmecaEntity);
        _logger.LogInformation($" New FMECA {newfmecaEntity.FMECAID} is successfully created.");
        return newfmecaEntity.FMECAID;
    }
}
