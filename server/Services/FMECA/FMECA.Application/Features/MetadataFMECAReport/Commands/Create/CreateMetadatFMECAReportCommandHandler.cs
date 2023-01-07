using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using FMECA.Domain.Entities;
namespace FMECA.Application.Features.MetadataFMECAReport.Commands.Insert;

public class CreateMetadatFMECAReportCommandHandler : IRequestHandler<CreateMetadatFMECAReportCommand, string>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateMetadatFMECAReportCommandHandler> _logger;

    public CreateMetadatFMECAReportCommandHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<CreateMetadatFMECAReportCommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> Handle(CreateMetadatFMECAReportCommand request, CancellationToken cancellationToken)
    {
        var fmecaEntity= _mapper.Map<Domain.Entities.MetadataFMECA>(request);
        var newfmecaEntity= await _fmecaDetailsRepository.AddAsync(fmecaEntity);
        _logger.LogInformation($" New FMECA {newfmecaEntity.FMECANumber} is successfully created.");
        return newfmecaEntity.FMECANumber;
    }
}
