using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using FMECA.Domain.Entities;
namespace FMECA.Application.Features.FMECA.Commands.Insert;

public class CreateFMECACommandHandler : IRequestHandler<CreateFMECACommand, string>
{
    private readonly IFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateFMECACommandHandler> _logger;

    public CreateFMECACommandHandler(IFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<CreateFMECACommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> Handle(CreateFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaEntity= _mapper.Map<Domain.Entities.FMECA>(request);
        var newfmecaEntity= await _fmecaDetailsRepository.AddAsync(fmecaEntity);
        _logger.LogInformation($" New FMECA {newfmecaEntity.FMECANumber} is successfully created.");
        return newfmecaEntity.FMECANumber;
    }
}
