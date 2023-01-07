using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.MetadataFMECAReport.Commands.Update;

public class UpdateMetadatFMECAReportCommandHandler : IRequestHandler<UpdateMetadatFMECAReportCommand>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateMetadatFMECAReportCommand> _logger;

    public UpdateMetadatFMECAReportCommandHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<UpdateMetadatFMECAReportCommand> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateMetadatFMECAReportCommand request, CancellationToken cancellationToken)
    {
        var fmecaToUpdate = await _fmecaDetailsRepository.GetByIdAsync(request.FMECANumber);
        if (fmecaToUpdate == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.MetadataFMECA), request.FMECANumber);
        }

        _mapper.Map(request, fmecaToUpdate, typeof(UpdateMetadatFMECAReportCommand), typeof(Domain.Entities.MetadataFMECA));
        await _fmecaDetailsRepository.UpdateAsync(fmecaToUpdate);
        _logger.LogInformation($"Order {fmecaToUpdate.FMECANumber} is successfully updated.");
        return Unit.Value;
    }
}
