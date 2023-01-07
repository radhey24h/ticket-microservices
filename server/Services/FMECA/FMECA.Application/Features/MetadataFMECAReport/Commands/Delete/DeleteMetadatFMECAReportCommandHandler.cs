using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.MetadataFMECAReport.Commands.Delete;

public class DeleteMetadatFMECAReportCommandHandler : IRequestHandler<DeleteMetadatFMECAReportCommand>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteMetadatFMECAReportCommandHandler> _logger;

    public DeleteMetadatFMECAReportCommandHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<DeleteMetadatFMECAReportCommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteMetadatFMECAReportCommand request, CancellationToken cancellationToken)
    {
        var fmecaToDelete = await _fmecaDetailsRepository.GetByIdAsync(request.FMECANumber);
        if (fmecaToDelete == null)
        {
             throw new NotFoundException(nameof(fmecaToDelete), request.FMECANumber);
        }
        await _fmecaDetailsRepository.DeleteAsync(fmecaToDelete);
        _logger.LogInformation($" FMECA {fmecaToDelete.FMECANumber} is deleted successfully.");
        return Unit.Value;
    }
}