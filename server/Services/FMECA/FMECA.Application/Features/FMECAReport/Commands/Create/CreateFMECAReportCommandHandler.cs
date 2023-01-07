using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using FMECA.Domain.Entities;
namespace FMECA.Application.Features.FMECAReport.Commands.Insert;

public class CreateFMECAReportCommandHandler : IRequestHandler<CreateFMECAReportCommand, string>
{
    private readonly IFMECAReportRepository _fmecaReportRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateFMECAReportCommandHandler> _logger;

    public CreateFMECAReportCommandHandler(IFMECAReportRepository fmecaReportRepository, IMapper mapper, ILogger<CreateFMECAReportCommandHandler> logger)
    {
        _fmecaReportRepository = fmecaReportRepository ?? throw new ArgumentNullException(nameof(fmecaReportRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> Handle(CreateFMECAReportCommand request, CancellationToken cancellationToken)
    {
        var fmecaEntity= _mapper.Map<Domain.Entities.FMECAReport>(request);
        var newfmecaEntity= await _fmecaReportRepository.AddAsync(fmecaEntity);
        _logger.LogInformation($" New FMECA {newfmecaEntity.FMECANumber} is successfully created.");
        return newfmecaEntity.FMECANumber;
    }
}
